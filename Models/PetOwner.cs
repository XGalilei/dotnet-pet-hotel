using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace pet_hotel
{
    public class PetOwner {
        [Key]
        public int id {get; set;}
        
        [Required]
        public string name {get; set;}
        [Required]
        public string emailAddress {get; set;}
        
        [NotMapped]
        public int petCount {get; set;}

        [JsonIgnore]
        public List<Pet> pets;

        public PetOwner(string name, string emailAddress) {
            this.name = name;
            this.emailAddress = emailAddress;
            pets = new List<Pet>();
        }
    }
}



