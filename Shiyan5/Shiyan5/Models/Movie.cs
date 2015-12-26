using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Shiyan5.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Display(Name="电影名称")]
        [Required(ErrorMessage ="必填")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="必须是[3,60]个字符")]
        public String Title { get; set; }

        [Display(Name = "上映日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "电影类型")]
        [Required]
        public String Genre { get; set; }

        [Display(Name = "电影票价")]
        [Range(1,100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "电影分级")]
        [StringLength(5)]
        [Required]
        public String Rating { get; set; }

    }

    public class MovieDBContext : DbContext
    {
       public DbSet<Movie> Movies { get; set; }
    }
}