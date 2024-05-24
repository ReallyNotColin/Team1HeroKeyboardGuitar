using NAudio.Wave;

namespace AudioAnalyzing;

/// <summary>
/// Basic class for analyzing an audio file. Stores samples and 
/// does cluster analysis.
/// </summary>
public class Audio {
    private double[] samples;
    private WaveOutEvent outputDevice;
    public WaveOutEvent OutputDevice => outputDevice;
    private string filePath;
    public AudioFileReader fileReader;
    private List<double> clusters;

    /// <summary>
    /// The times at which the music hits a peak. Useful for generating points
    /// were the player must hit a key to the beat
    /// </summary>
    public List<double> ActionTimes { get; private set; }

    /// <summary>
    /// The song's total duration in milliseconds
    /// </summary>
    public double AudioLengthInMs { get; private set; }

    /// <summary>
    /// Total number of bytes 
    /// </summary>
    public long StreamLengthInBytes { get; private set; }

    /// <summary>
    /// Takes in a file path and starts analysis right away.
    /// Stores the results of that analysis
    /// </summary>
    /// <param name="filePath">Full absolute path to the .wav file</param>
    public Audio(string filePath) {
        this.filePath = filePath;
        fileReader = new AudioFileReader(filePath);
        int sampleRate = fileReader.WaveFormat.SampleRate;
        int sampleCount = (int)(fileReader.Length / fileReader.WaveFormat.BitsPerSample / 8);
        int channelCount = fileReader.WaveFormat.Channels;
        var samplesList = new List<double>(sampleCount);
        var buffer = new float[sampleRate * channelCount];
        int samplesRead = 0;
        while ((samplesRead = fileReader.Read(buffer, 0, buffer.Length)) > 0) {
            samplesList.AddRange(buffer.Take(samplesRead).Select(x => (double)x));
        }
        samples = samplesList.ToArray();
        AudioLengthInMs = fileReader.TotalTime.TotalMilliseconds;
        StreamLengthInBytes = fileReader.Length;
        outputDevice = new();

        ActionTimes = new();
        clusters = new();
        List<double> curCluster = new();
        double THRES = 0.4;
        bool inCluster = false;
        const int MAX_TOLERANCE = 500;
        int curTolerance = 0;
        int clusterStart = -1;
        for (int i = 0; i < samples.Length; i++) {
            var sample = Math.Abs(samples[i]);
            if (!inCluster) {
                if (Math.Abs(sample) > THRES) { // start
                    inCluster = true;
                    curTolerance = 0;
                    curCluster = new();
                    clusterStart = i;
                    clusters.Add(THRES);
                    curCluster.Add(sample);
                }
                else {
                    clusters.Add(0.0);
                }
            }
            else {
                if (Math.Abs(sample) < THRES / 1.5) {
                    curTolerance++;
                    if (curTolerance >= MAX_TOLERANCE) {
                        inCluster = false;
                        int actionIndex = clusterStart + curCluster.IndexOf(curCluster.Max());
                        double actionTime = (actionIndex / (double)samples.Length) * AudioLengthInMs;
                        ActionTimes.Add(actionTime);
                        clusters.Add(0.0);
                        curCluster.Add(0.0);
                    }
                    else {
                        clusters.Add(THRES);
                        curCluster.Add(sample);
                    }
                }
                else {
                    curTolerance = 0;
                    clusters.Add(THRES);
                    curCluster.Add(sample);
                }
            }
        }
    }

    /// <summary>
    /// Only used for debugging cluster analysis. Use these files in the Octave "reload.m" script
    /// which is in the "Audio Analysis via Octave" folder
    /// </summary>
    public void DebugFileWrite() {
        File.WriteAllText("samples.txt", string.Join(',', samples.Select(x => Math.Abs(x))));
        File.WriteAllText("clusters.txt", string.Join(',', clusters));
        File.WriteAllText("actiontimes.txt", string.Join(',', ActionTimes));
    }
        
    /// <summary>
    /// Gets the index of the current sample being played
    /// </summary>
    /// <returns>Index/Position of the sample being played</returns>
    public int GetPosition() {
        double perComplete = outputDevice.GetPosition() / (double)StreamLengthInBytes;
        return (int)Math.Clamp(perComplete * samples.Length, 0, samples.Length - 1);
    }

    /// <summary>
    /// Retrieves the total number of samples for this song
    /// </summary>
    /// <returns>Total number of samples</returns>
    public int GetNumberOfSamples() {
        return samples.Length;
    }

    /// <summary>
    /// Start playing the audio
    /// </summary>
    public void Play() {
        fileReader = new AudioFileReader(filePath);
        outputDevice.Init(fileReader);
        outputDevice.Play();
    }

    /// <summary>
    /// Stop playing the audio
    /// </summary>
    public void Stop() {
        outputDevice.Stop();
    }
}
