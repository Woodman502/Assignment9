using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework9.Models
{
    public class HotDogUser
    {
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string FavoriteDog { get; set; }
        public virtual PastDogs PastDog { get; set; }

        
    }

    public class PastDogs
    {
        
        public int Id { get; set; }
        public string DogName { get; set; }
        public DateTime Date { get; set; }
    }
}