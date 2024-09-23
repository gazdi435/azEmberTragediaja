using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models;
internal abstract class Queryable<T>
{
    public Queryable(T prop) { }
}

internal class Queryable: Queryable<MySqlDataReader>
{
    public Queryable(MySqlDataReader reader): base(reader) { }
}