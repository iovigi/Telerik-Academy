using MusicSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicSystem.Web.Controllers
{
    public class AlbumsController : ApiController
    {
        private MusicsEntities context;

        public AlbumsController()
            : this(new MusicsEntities())
        {
        }

        public AlbumsController(MusicsEntities context)
        {
            this.context = context;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(context.Albums.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(context.Albums.FirstOrDefault(x => x.Id == id));
        }

        public void Post(Album album)
        {
            context.Albums.Add(album);

            context.SaveChanges();
        }

        public void Put(int id, [FromBody]Album album)
        {
            var alb = context.Albums.FirstOrDefault(x => x.Id == id);

            if (alb != null)
            {
                alb.AlbumsArtists = album.AlbumsArtists;
                alb.Producer = album.Producer;
                alb.Title = album.Title;
                alb.Year = album.Year;
                alb.SongsAlbums = album.SongsAlbums;
            }
            else
            {
                context.Albums.Add(album);
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var album = context.Albums.FirstOrDefault(x => x.Id == id);

            if (album != null)
            {
                context.Albums.Remove(album);
            }

            context.SaveChanges();
        }
    }
}
