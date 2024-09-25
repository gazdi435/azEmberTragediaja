using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Models;
public abstract class Queryable<T>
{
    public Queryable(T prop) { }
}

public class Queryable: Queryable<MySqlDataReader>
{
    public Queryable(MySqlDataReader reader): base(reader) { }
}