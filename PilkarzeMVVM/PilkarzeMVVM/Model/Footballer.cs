namespace PilkarzeMVVM
{
    public class Footballer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public uint Age { get; set; }
        public uint Weight { get; set; }
        public uint Height { get; set; }


        public Footballer(int id, string firstName, string surname, uint age, uint weight, uint height)
        {
            Id = id;
            FirstName = firstName;
            Surname = surname;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return $"Name: {FirstName}  Surname: {Surname}  Age: {Age}  Weight: {Weight}kg  Height: {Height}cm";
        }


    }
}
