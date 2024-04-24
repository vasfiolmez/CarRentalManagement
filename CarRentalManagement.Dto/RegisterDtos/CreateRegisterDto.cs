using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Dto.RegisterDtos
{
	public class CreateRegisterDto
	{
		[Required(ErrorMessage ="Kullanıcı Adı  Gereklidir.")]
		public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Gereklidir.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre Doğrulama Alanı Gereklidir.")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Ad Alanı Gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Gereklidir.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email Alanı Gereklidir.")]
        public string Email { get; set; }
	}
}
