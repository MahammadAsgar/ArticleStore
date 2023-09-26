using ArticleStore.Domain.Models.Users;

namespace ArticleStore.Infrasturucture.Dtos.Users.Post
{
    public class SignupDTO
    {
        public string fullName { get; set; }
        public string email { get; set; }
        public int genderId { get; set; }
        public int countryId { get; set; }
        public DateTime birthDate { get; set; }
        public string password { get; set; }


        public static AppUser ToAppUser(SignupDTO signupDTO)
        {
            var userName = $"{signupDTO.fullName.Length}{signupDTO.birthDate.DayOfYear}_{Guid.NewGuid()}";


            return new AppUser()
            {
                FullName = signupDTO.fullName,
                BirthDate = signupDTO.birthDate,
                Email = signupDTO.email,
                UserName = userName, 
                GenderId= signupDTO.genderId,
                CountryId= signupDTO.countryId
            };
        }
    }
}


