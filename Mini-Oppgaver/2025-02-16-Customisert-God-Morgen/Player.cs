using NAudio.Wave;
namespace _2025_02_16_Customisert_God_Morgen;
class MusicPlayer
{
  public static void Player(string path)
  {
    if (!File.Exists(path))
    {
      Console.WriteLine($"\nFile {path} not found!");
      return;
    }
    string songName = Path.GetFileName(path);

    using (var audioFile = new AudioFileReader(path))
    using (var outputDevice = new WaveOutEvent())
    {
      audioFile.Volume = 0.5f; // Initial volume 50%

      outputDevice.Init(audioFile);
      outputDevice.Play();

      bool isPaused = false; // Pause flag

      Console.WriteLine($"🎵 {StylesClass.REVERSE}Player launched!\x1B[27m");
      Console.WriteLine($"Playing:  {StylesClass.BOLD}{songName}\x1B[22m");
      Console.WriteLine("Control: ▶ [Spacebar] Pause, 🔊 [+/-] Volume,  ⏹ [Enter] Exit");

      Console.WriteLine($"{StylesClass.BOLD}Enjoy!\x1B[22m");

      Console.WriteLine($"{StylesClass.ITALIC}The program will end after the track has ended.\x1B[23m");

      // Automatically close the program after the end of the track
      outputDevice.PlaybackStopped += (sender, args) =>
      {
        Console.WriteLine("The music has ended. Exit program.");
        Console.WriteLine($"{StylesClass.RESET}");
        Environment.Exit(0);
      };

      // Real-time volume control
      while (true)
      {
        if (Console.KeyAvailable)
        {
          var key = Console.ReadKey(true).Key;
          if (key == ConsoleKey.Enter) break; //exit
          if (key == ConsoleKey.OemPlus || key == ConsoleKey.Add)
          {
            audioFile.Volume = Math.Min(audioFile.Volume + 0.1f, 1.0f);
            Console.WriteLine($"🔊 + : {audioFile.Volume * 100}%");
          }
          else if (key == ConsoleKey.OemMinus || key == ConsoleKey.Subtract)
          {
            audioFile.Volume = Math.Max(audioFile.Volume - 0.1f, 0.0f);
            Console.WriteLine($"🔊 - : {audioFile.Volume * 100}%");
          }
          else if (key == ConsoleKey.Spacebar)
          {
            if (isPaused)
            {
              outputDevice.Play();
              Console.WriteLine("▶  Playing");
            }
            else
            {
              outputDevice.Pause();
              Console.WriteLine("⏸  Paused. Press `Spacebar` to continue playing");
            }
            isPaused = !isPaused;
          }
        }
      }
      // If Enter is pressed, the program will be terminated manually.
      Console.WriteLine($"{StylesClass.RESET}");
      outputDevice.Stop();
    }
  }
}