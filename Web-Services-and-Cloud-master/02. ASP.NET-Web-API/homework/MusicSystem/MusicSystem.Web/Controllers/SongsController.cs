using MusicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicSystem.Web.Controllers
{
    public class SongsController : ApiController
    {
        private MusicsEntities context;

        public SongsController()
            : this(new MusicsEntities())
        {
        }

        public SongsController(MusicsEntities context)
        {
            this.context = context;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(context.Songs.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(context.Songs.FirstOrDefault(x => x.Id == id));
        }

        public void Post(Song song)
        {
            context.Songs.Add(song);

            context.SaveChanges();
        }

        public void Put(int id, [FromBody]Song song)
        {
            var s = context.Songs.FirstOrDefault(x => x.Id == id);

            if (s != null)
            {
                s.Artist = song.Artist;
                s.ArtistsId = song.ArtistsId;
                s.Genre = song.Genre;
                s.SongsAlbums = song.SongsAlbums;
                s.Title = song.Title;
                s.Year = song.Year;
            }
            else
            {
                context.Songs.Add(song);
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var song = context.Songs.FirstOrDefault(x => x.Id == id);

            if (song != null)
            {
                context.Songs.Remove(song);
            }

            context.SaveChanges();
        }
    }
}
