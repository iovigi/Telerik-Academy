using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicSystem.Data;

namespace MusicSystem.Web.Controllers
{
    public class ArtistsController : ApiController
    {
        private MusicsEntities context;

        public ArtistsController()
            : this(new MusicsEntities())
        {
        }

        public ArtistsController(MusicsEntities context)
        {
            this.context = context;
        }

        public IHttpActionResult Get()
        {
            return this.Ok(context.Artists.ToList());
        }

        public IHttpActionResult Get(int id)
        {
            return this.Ok(context.Artists.FirstOrDefault(x => x.Id == id));
        }

        public void Post(Artist artist)
        {
            context.Artists.Add(artist);

            context.SaveChanges();
        }

        public void Put(int id, [FromBody]Artist artist)
        {
            var art = context.Artists.FirstOrDefault(x => x.Id == id);

            if (art != null)
            {
                art.AlbumsArtists = artist.AlbumsArtists;
                art.Country = artist.Country;
                art.Name = artist.Name;
                art.DateIfBurth = artist.DateIfBurth;
                art.Songs = artist.Songs;
            }
            else
            {
                context.Artists.Add(artist);
            }

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var artist = context.Artists.FirstOrDefault(x => x.Id == id);

            if (artist != null)
            {
                context.Artists.Remove(artist);
            }

            context.SaveChanges();
        }
    }
}
