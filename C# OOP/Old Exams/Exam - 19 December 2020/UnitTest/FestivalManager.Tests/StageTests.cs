// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    //using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StageTests
    {
        private List<Song> songs;
        private List<Performer> performers;
        private Stage stage;
        private Song song1;
        private Performer performenr1;

        [SetUp]
        public void SetUp()
        {
            songs = new List<Song>();
            performers = new List<Performer>();
            stage = new Stage();

            song1 = new Song("Milko", new TimeSpan(0, 3, 30));
            performenr1 = new Performer("gosho", "goshev", 19);
        }

        [Test]
        public void Check_Prop_Setters()
        {
            string expectedName = "gosho goshev";

            Assert.AreEqual(performenr1.FullName, expectedName);
            Assert.AreEqual(performenr1.Age, 19);
            Assert.AreEqual(performenr1.SongList, string.Empty);
        }

        [Test]
        public void Check_Ctor_Setters()
        {
            performers = new List<Performer> { performenr1 };
            stage.AddPerformer(performenr1);

            Assert.AreEqual(stage.Performers, performers);
        }


        [Test]
        public void Check_PrivateValidator_ForAddPerformer()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddPerformer(null);
            });
        }

        [Test]
        public void AddPerformer_ShouldThrowExeption_IfPerformerAgeIsLessThanConst()
        {
            performenr1 = new Performer("pesho", "peshev", 17);

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddPerformer(performenr1);

            }, "You can only add performers that are at least 18.");
        }

        [Test]
        public void Check_PrivateValidator_ForAddSong()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSong(null);
            });
        }

        [Test]
        public void AddSong_ShouldThrowExeptionIfSongDurationIsLessThanOneMinut()
        {
            song1 = new Song("Peq", new TimeSpan(0, 0, 30));

            Assert.Throws<ArgumentException>(() =>
            {
                stage.AddSong(song1);
            });
        }

        [Test]
        public void Check_SongSetters_WhenAddSong()
        {
            song1 = new Song("Peq", new TimeSpan(0, 3, 30));
            stage.AddSong(song1);

            Assert.AreEqual(song1.Name, "Peq");
            Assert.AreEqual(song1.Duration, new TimeSpan(0, 3, 30));
        }

        [Test]
        [TestCase(null, "gosho")]
        [TestCase("Milko", null)]
        public void Check_PrivateValidator_ForAddSongToPerformer(string songName, string performerName)
        {
            this.stage.AddPerformer(this.performenr1);
            this.stage.AddSong(this.song1);

            string missingName = songName == null ? songName : performerName;

            Assert.Throws<ArgumentNullException>(() =>
            {
                stage.AddSongToPerformer(songName, performerName);
            });
        }


        [Test]
        public void Check_SongSetters_WhenAddSongToPerformer()
        {
            song1 = new Song("Peq", new TimeSpan(0, 3, 30));
            stage.AddSong(song1);
            stage.AddPerformer(performenr1);
            stage.AddSongToPerformer(song1.Name, performenr1.FullName);

            Assert.AreEqual(song1.Name, "Peq");
            Assert.AreEqual(song1.Duration, new TimeSpan(0, 3, 30));
        }

        [Test]
        public void AddSongToPerformer_ShouldAddSongToList()
        {
            song1 = new Song("Peq", new TimeSpan(0, 3, 30));
            stage.AddSong(song1);
            stage.AddPerformer(performenr1);
            stage.AddSongToPerformer(song1.Name, performenr1.FullName);
            songs.Add(song1);

            Assert.AreEqual(performenr1.SongList, songs);
        }

        [Test]
        public void Check_PerformerSetters_WhenAddSongToPerformer()
        {
            stage.AddSong(song1);
            stage.AddPerformer(performenr1);
            stage.AddSongToPerformer(song1.Name, performenr1.FullName);

            Assert.AreEqual(performenr1.FullName, "gosho goshev");
            Assert.AreEqual(performenr1.Age, 19);
        }

        [Test]
        public void AddSongToPerformer_SholdReturnCorectMassage()
        {
            string expectedOutput = $"{song1} will be performed by {performenr1}";
            stage.AddPerformer(performenr1);
            stage.AddSong(song1);
            string result = stage.AddSongToPerformer(song1.Name, performenr1.FullName);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void AddPerformer_ShouldAddPerformerToList()
        {
            stage.AddPerformer(performenr1);
            performers.Add(performenr1);

            Assert.AreEqual(stage.Performers, performers);
        }

        [Test]
        public void PlayMethood_Should_ReturnCorectly()
        {
            stage.AddPerformer(performenr1);
            stage.AddSong(song1);
            stage.AddSongToPerformer(song1.Name, performenr1.FullName);

            string espectedOutput = $"{1} performers played {1} songs";
            string actualOutPut = stage.Play();

            Assert.AreEqual(espectedOutput, actualOutPut);
        }
    }
}