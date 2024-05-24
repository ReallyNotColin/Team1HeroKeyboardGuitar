using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace HeroKeyboardGuitar;

/*
 * this page right here is a god damn godsend https://mysqlconnector.net/tutorials/connect-ssh/
 * reference btw
 * https://www.connectionstrings.com/mysql-connector-net-mysqlconnection/
 * https://github.com/mysql-net/MySqlConnector/issues/571
 * These arent the only references i used but i cannot find the other ones but these helped out a lot
 */

internal static class ScoreTracker
{


    /*
     * To get this to work you need to have an ssh server setup running a mysql server
     * change sshHost to your ssh server ip addr
     * change sshUsername to your user
     * change sshPassword to your user password ( i know its in plaintext and thats really insecure but getting it to work with secret files or encryption was wacky )
     * change mysqlUser to root or whatever user you want to use
     * change mysqlPassowrd to your password
     * 
     * if you are running your sql server on a different port change it to that port
     * if you have your sql server to accept all remote users change mysqlHost to 0.0.0.0
     * 
     */
    private const string sshHost = "138.47.149.72";
    private const string sshUsername = "";
    private const string sshPassword = "";
    private const int sshPort = 22;

    private const string mysqlHost = "127.0.0.1";
    private const int mysqlPort = 3306;
    private const string mysqlDatabase = "PlayerScoresDB";
    private const string mysqlUser = "";
    private const string mysqlPassword = "";

    private static SshClient sshClient;
    private static ForwardedPortLocal portForwarded;

    private static (SshClient SshClient, uint Port) SetupSshTunnel()
    {
        try
        {
            sshClient = new SshClient(sshHost, sshPort, sshUsername, sshPassword);
            sshClient.HostKeyReceived += delegate (object sender, HostKeyEventArgs e)
            {
                Console.WriteLine("Host key: " + BitConverter.ToString(e.FingerPrint).Replace("-", ":"));
                e.CanTrust = true;
            };

            Console.WriteLine("Connecting to SSH server...");
            sshClient.Connect();
            Console.WriteLine("Connected to SSH server.");

            portForwarded = new ForwardedPortLocal("127.0.0.1", mysqlHost, (uint)mysqlPort);
            sshClient.AddForwardedPort(portForwarded);
            portForwarded.Start();
            Console.WriteLine("Port forwarding started.");
        }
        catch (SshException ex)
        {
            Console.WriteLine("SSH Exception: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
            throw;
        }

        return (sshClient, portForwarded.BoundPort); 
    }

    private static void CloseSshTunnel()
    {
        if (portForwarded != null)
        {
            portForwarded.Stop();
            portForwarded.Dispose();
        }

        if (sshClient != null)
        {
            sshClient.Disconnect();
            sshClient.Dispose();
        }
    }

    private static MySqlConnectionStringBuilder GetMySqlConnectionString()
    {
        var (sshClient, localPort) = SetupSshTunnel();
        MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            Port = localPort,
            UserID = mysqlUser,
            Password = mysqlPassword,
            Database = mysqlDatabase,
        };

        return csb;
    }

    private static void CreateSongTableIfNotExists(string tableName)
    {
        using (var connection = new MySqlConnection(GetMySqlConnectionString().ConnectionString))
        {
            try
            {
                string query = $"CREATE TABLE IF NOT EXISTS `{tableName}` (" +
                               "PlayID INT PRIMARY KEY AUTO_INCREMENT," +
                               "PlayerID VARCHAR(3)," +
                               "PlayTime DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                               "Score VARCHAR(10));";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    Console.WriteLine("MySQL connection opened.");
                    command.ExecuteNonQuery();
                    Console.WriteLine("Table created if it did not exist.");
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                throw;
            }
        }
    }

    internal static void InsertPlayData(string tableName, string playerId, string score)
    {
        CreateSongTableIfNotExists(tableName);

        using (var connection = new MySqlConnection(GetMySqlConnectionString().ConnectionString))
        {
            try
            {
                string query = $"INSERT INTO `{tableName}` (PlayerID, Score) VALUES (@PlayerID, @Score)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PlayerID", playerId);
                    command.Parameters.AddWithValue("@Score", score);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                throw;
            }
        }

        CloseSshTunnel();
    }

    internal static DataTable RetrievePlayData(string tableName, int topN = -1)
    {
        DataTable playDataTable = new DataTable();
        try
        {
            using (var connection = new MySqlConnection(GetMySqlConnectionString().ConnectionString))
            {
                string query = $"SELECT * FROM `{tableName}`";
                if (topN > 0)
                {
                    query += $" ORDER BY CAST(Score AS UNSIGNED) DESC LIMIT {topN}";
                }
                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(playDataTable);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            throw;
        }
        finally
        {
            CloseSshTunnel();
        }
        return playDataTable;
    }

    internal static DataTable GetTopScores(string tableName, int topN = 5)
    {
        return RetrievePlayData(tableName, topN);
    }

}

