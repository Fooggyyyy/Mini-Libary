using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Libary
{
    public class BookComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            if (x == null || y == null) return false;

            return x.TitleB == y.TitleB && x.YearB == y.YearB && x.AuthorB.NameA == y.AuthorB.NameA
                && x.AuthorB.SurNameA == y.AuthorB.SurNameA;
        }

        public int GetHashCode(Book obj)
        {
            if (obj == null) return 0;

            int hashTitle = obj.TitleB == null ? 0 : obj.TitleB.GetHashCode();
            int hashYear = obj.YearB.GetHashCode();
            int hashAuthorName = obj.AuthorB.NameA == null ? 0 : obj.AuthorB.NameA.GetHashCode();
            int hashAuthorSurname = obj.AuthorB.SurNameA == null ? 0 : obj.AuthorB.SurNameA.GetHashCode();

            return hashTitle ^ hashYear ^ hashAuthorName ^ hashAuthorSurname;
        }
    }
}
