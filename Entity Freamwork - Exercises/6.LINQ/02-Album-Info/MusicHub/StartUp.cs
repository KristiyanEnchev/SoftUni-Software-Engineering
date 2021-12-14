namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //int producerId = int.Parse(Console.ReadLine());
            //Console.WriteLine(ExportAlbumsInfo(context, producerId));

            Console.WriteLine(ExportSongsAboveDuration(context,4));

        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albums = context.Albums
                .Where(x => x.ProducerId == producerId)
                .Select(x => new
                {
                    AlbumName = x.Name,
                    AlbumReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                    AlbumPrice = x.Price,
                    ProducerName = x.Producer.Name,
                    Songs = x.Songs.Select(s => new
                    {
                        SongName = s.Name,
                        SongPrice = s.Price,
                        SongWriter = s.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName).ThenBy(x => x.SongWriter).ToList()
                })
                .OrderByDescending(a => a.AlbumPrice)
                .ToList();


            foreach (var Album in albums)
            {
                sb.AppendLine($"-AlbumName: {Album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {Album.AlbumReleaseDate}");
                sb.AppendLine($"-ProducerName: {Album.ProducerName}");
                sb.AppendLine($"-Songs:");
                int count = 1;
                foreach (var song in Album.Songs)
                {
                    sb.AppendLine($"---#{count}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");

                    count++;
                }
                sb.AppendLine($"-AlbumPrice: {Album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .Where(x => x.Duration > TimeSpan.FromSeconds(duration))
                .Select(s => new
                {
                    SongId = s.Id,
                    SongName = s.Name,
                    PerformerName=s.SongPerformers.Select(y=>y.Performer.FirstName+" "+y.Performer.LastName).FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerName)
                .ToList();

            int count = 1;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{count}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
                count++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
