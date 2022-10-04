using System.Linq.Expressions;
using System.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace day_1
{
    public class ManageMember
    {
        public static List<Member> listMember = new List<Member>();

        public static void ListMember()
        {
            listMember.Add(new Member
            {
                FirstName = "Loc   ",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 1, 21),
                BirthPlace = "BacNinh",
                PhoneNumber = "0961564730",
                IsGraduated = false
            });

            listMember.Add(new Member
            {
                FirstName = "Hung",
                LastName = "Vu",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 8, 6),
                BirthPlace = "Lao Cai",
                PhoneNumber = "0345801331",
                IsGraduated = false
            });

            listMember.Add(new Member
            {
                FirstName = "Linh",
                LastName = "Nhat",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 7, 24),
                BirthPlace = "Ha Noi",
                PhoneNumber = "0977652575",
                IsGraduated = true
            });


        }
        public static void FindMale()
        {
            var findmale = from member in listMember
                           where member.Gender == "Male"
                           select member;
            foreach (Member member in findmale)
            {

                Console.WriteLine(member.Info);
            }
        }
        public static void FindOldest()
        {
            var maxAge = listMember.Max(member => member.Age);
            var findoldest = from member in listMember
                             where member.Age == maxAge
                             select member;
            foreach (Member member in findoldest)
            {
                Console.WriteLine(member.Info);
            }

        }
        public static void FullName()
        {
            var fullname = listMember.Select(p => new {Fullname = p.FirstName + "" + p.LastName });
            foreach (Member member in listMember)
            {
                Console.WriteLine(fullname);
            }
        }

        public static void FindYear()
        {
            int key = 0;
            while (key != 4)
            {
                key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        {
                            //var born2000 = listMember.FindAll(m => m.DateOfBirth.Year == 2000);
                            //var born2000 = listMember.Where(m => m.DateOfBirth.Year ==2000 );
                            //var born20001 = listMember.TakeWhile(x => x.DateOfBirth.Year == 2000);
                            var born20003 = listMember.Select(y => y.DateOfBirth);
                            var born2000 = from member in listMember
                                           where member.DateOfBirth.Year == 2000
                                           select member;
                            Console.WriteLine("List members born in 2000: ");

                            foreach (Member member in born2000)
                            {
                                Console.WriteLine(member.Info);
                            }
                            break;
                        }
                    case 2:
                        {
                            var bornbf2000 = from member in listMember
                                             where member.DateOfBirth.Year < 2000
                                             select member;
                            Console.WriteLine("List members born before 2000: ");

                            foreach (Member member in bornbf2000)
                            {
                                Console.WriteLine(member.Info);
                            }
                            break;
                        }
                    case 3:
                        {
                            var bornaf2000 = from member in listMember
                                             where member.DateOfBirth.Year > 2000
                                             select member;
                            Console.WriteLine("List members born after 2000: ");

                            foreach (Member member in bornaf2000)
                            {
                                Console.WriteLine(member.Info);
                            }
                            break;
                        }
                }
                break;
            }
        }
        public static void FindFirstPersonWasBornHaNoi()
        {
            int index = 0;
            var borninhn = from member in listMember
                           where member.BirthPlace == "Ha Noi"
                           orderby index
                           select member;
            foreach (Member member in borninhn)
            {
                Console.WriteLine(member.Info);

            }
            ++index;
        }
    }
}
