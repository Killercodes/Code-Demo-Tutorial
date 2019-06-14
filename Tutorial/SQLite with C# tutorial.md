# SQLite with C# tutorial
> This is a C# tutorial for the SQLite database. It covers the basics of SQLite programming with C#. The examples were created and tested on Linux.

## Table of Contents
-Introduction
-Reading data with SqliteDataReader
-DataSet
-Working with images
-Getting database metadata
-Transactions

## SQLite & C#
SQLite is an embedded relational database engine. It is a self-contained, serverless, zero-configuration and transactional SQL database engine. SQLite implements most of the SQL-92 standard for SQL. The SQLite engine is not a standalone process. Instead, it is statically or dynamically linked into the application. An SQLite database is a single ordinary disk file that can be located anywhere in the directory hierarchy.

C# is a modern, high-level, general-purpose, object-oriented programming language. It is the principal language of the .NET framework. The design goals of the language were software robustness, durability and programmer productivity. It can be used to create console applications, GUI applications, web applications, both on PCs or embedded systems.


## About SQLite database
SQLite is an embedded relational database engine. Its developers call it a self-contained, serverless, zero-configuration and transactional SQL database engine. It is very popular and there are hundreds of millions copies worldwide in use today. SQLite is used in Solaris 10 and Mac OS operating systems, iPhone or Skype. Qt4 library has a buit-in support for the SQLite as well as the Python or the PHP language. Many popular applications use SQLite internally such as Firefox or Amarok.

```bash
$ sudo apt-get install sqlite3
```
We need to install sqlite3 library if it is not installed already.

The SQLite comes with the sqlite3 command line utility. It can be used to issue SQL commands against a database. Now we are going to use the sqlite3 command line tool to create a new database.
``` bash
$ sqlite3 test.db
SQLite version 3.6.22
Enter ".help" for instructions
Enter SQL statements terminated with a ";"
```

We provide a parameter to the sqlite3 tool. The test.db is a database name. It is a single file on our disk. If it is present, it is opened. If not, it is created.
```bash
sqlite> .tables
sqlite> .exit
$ ls
test.db
```
The .tables command gives a list of tables in the test.db database. There are currently no tables. The .exit command terminates the interactive session of the sqlite3 command line tool. The ls Unix command shows the contents of the current working directory. We can see the test.db file. All data will be stored in this single file.

## ADO.NET
ADO.NET is an important part of the .NET framework. It is a specification that unifies access to relational databases, XML files, and other application data. From the programmer's point of view it is a set of libraries and classes to work with database and other data sources. A Mono.Data.SQLite is an implementation of the ADO.NET specification for the SQLite database. It is a driver written in C# language and is available for all .NET languages.

SqliteConnection, SqliteCommand, SqliteDataReader, SqliteDataAdapter are the core elements of the .NET data provider model. The SqliteConnection creates a connection to a specific data source. The SqliteCommand object executes an SQL statement against a data source. The SqliteDataReader reads streams of data from a data source. A SqliteDataAdapter is an intermediary between the DataSet and the data source. It populates a DataSet and resolves updates with the data source.


 
The DataSet object is used for offline work with a mass of data. It is a disconnected data representation that can hold data from a variety of different sources. Both SqliteDataReader and DataSet are used to work with data; they are used under different circumstances. If we only need to read the results of a query, the SqliteDataReader is the better choice. If we need more extensive processing of data, or we want to bind a Winforms control to a database table, the DataSet is preferred.

## SQLite version
If the first program, we check the version of the SQLite database.

``` csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

	static void Main() 
	{
		string cs = "Data Source=:memory:";

		SqliteConnection con = null;
		SqliteCommand cmd = null;

		try 
		{
			con = new SqliteConnection(cs);
			con.Open();

			string stm = "SELECT SQLITE_VERSION()";   
			cmd = new SqliteCommand(stm, con);

			string version = Convert.ToString(cmd.ExecuteScalar());

			Console.WriteLine("SQLite version : {0}", version);
			
		} 
		catch (SqliteException ex) 
		{
			Console.WriteLine("Error: {0}",  ex.ToString());

		} 
		finally 
		{   
			if (cmd != null)
			{
				cmd.Dispose();
			}
		 
			if (con != null) 
			{
				try 
				{
					con.Close();

				} catch (SqliteException ex)
				{ 
					Console.WriteLine("Closing connection failed.");
					Console.WriteLine("Error: {0}",  ex.ToString());
					
				} finally 
				{
					con.Dispose();
				}
			}                        
		}
	}
}
```

We connect to an in-memory database and select an SQLite version.

`using Mono.Data.Sqlite;`
The Mono.Data.SqliteClient assembly contains an ADO.NET data provider for the SQLite database engine. We import the elements of the SQLite data provider.

`string cs = "Data Source=:memory:";`
This is the connection string. It is used by the data provider to establish a connection to the database. We create an in-memory database.

```con = new SqliteConnection(cs);```
A SqliteConnection object is created. This object is used to open a connection to a database.

```con.Open();```
This line opens the database connection.

```string stm = "SELECT SQLITE_VERSION()";   ```
This is the SQL SELECT statement. It returns the version of the database. The SQLITE_VERSION() is a built-in SQLite function.

```SqliteCommand cmd = new SqliteCommand(stm, con);```
The SqliteCommand is an object, which is used to execute a query on the database. The parameters are the SQL statement and the connection object.

```string version = Convert.ToString(cmd.ExecuteScalar());```
There are queries which return only a scalar value. In our case, we want a simple string specifying the version of the database. The ExecuteScalar() is used in such situations. We avoid the overhead of using more complex objects.

```Console.WriteLine("SQLite version : {0}", version);```
The version of the database is printed to the console.

``` csharp
} catch (SqliteException ex) 
{
    Console.WriteLine("Error: {0}",  ex.ToString());
```
In case of an exception, we print the error message to the console.
``` csharp
} finally 
{   
    if (cmd != null)
    {
        cmd.Dispose();
    }
```
The SqliteCommand class implements the IDisposable interface. Therefore it must be explicitly disposed.

``` csharp

if (con != null) 
{
    try 
    {
        con.Close();
    } 
	catch (SqliteException ex)
    { 
        Console.WriteLine("Closing connection failed.");
        Console.WriteLine("Error: {0}",  ex.ToString());
        
    } finally 
    {
        con.Dispose();
    }
}  
```


Closing connection may throw another exception. We handle this situation.

```$ dmcs version.cs -r:Mono.Data.Sqlite.dll```
We compile our example. A path to the SQLite data provider DLL is provided.
```
$ mono ./version.exe 
SQLite version : 3.7.7
```
This is the output of the program on our system.

### The using statement
The C# language implements garbage collection. It is a process of automatic release of objects that are no longer required. The process is non-deterministic. We cannot be sure when the CLR (Common Language Runtime) decides to release resources. For limited resources such as file handles or network connections it is best to release them as quickly as possible. With the using statement, the programmer controls when the resource is to be released. When the program is out of the using block, either reaches the end of it or an exception is thrown, the resource gets released.

Internally, the using statement is translated into try, finally blocks with a Dispose() call in the finally block. Note that you might prefer to use try, catch, finally blocks instead of the using statement. Especially, if you want to utilise the catch block explicitly. In this tutorial we have chosen the using statement. Mainly because the code is shorter.

As a rule, when we use an IDisposable object, we should declare and instantiate it in a using statement. (Or call Dispose() method in the finally block.) In the case of the SQLite ADO.NET driver, we use the using statement for the SqliteConnection, SqliteCommand, SqliteDataReader, SqliteCommandBuilder, and SqliteDataAdapter classes. We do not have to use it for DataSet or DataTable classes. They can be left for the garbage collector.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";

        using (SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();

            using (SqliteCommand cmd = new SqliteCommand(con))
            {
                cmd.CommandText = "SELECT SQLITE_VERSION()";
                string version = Convert.ToString(cmd.ExecuteScalar());

                Console.WriteLine("SQLite version : {0}", version);
            }             
            
            con.Close();
        }
    }
}
```
We have the same example. This time we implement the using keyword.
```csharp
using (SqliteConnection con = new SqliteConnection(cs)) 
{
    con.Open();
    using (SqliteCommand cmd = new SqliteCommand(con))
```


Both SqliteConnection and SqliteCommand implement the IDisposable interface. Therefore they are wrapped with the using keyword.


## Creating and populating a table
Next we are going to create a database table and fill it with data.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {

        string cs = "URI=file:test.db";

        using ( SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            using (SqliteCommand cmd = new SqliteCommand(con))
            {
                cmd.CommandText = "DROP TABLE IF EXISTS Cars";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE Cars(Id INTEGER PRIMARY KEY, Name TEXT, Price INT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(1,'Audi',52642)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(2,'Mercedes',57127)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(3,'Skoda',9000)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(4,'Volvo',29000)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(5,'Bentley',350000)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(6,'Citroen',21000)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(7,'Hummer',41400)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Cars VALUES(8,'Volkswagen',21600)";
                cmd.ExecuteNonQuery();
            }             

            con.Close();
        }
    }
}
```

In the above code example, we create a Cars table with 8 rows.
```
cmd.CommandText = "DROP TABLE IF EXISTS Cars";
cmd.ExecuteNonQuery();```
First we drop the table if it already exists. We can use the ExecuteNonQuery() method if we do not want a result set, for example for DROP, INSERT, or DELETE statements.
```
cmd.CommandText = @"CREATE TABLE Cars(Id INTEGER PRIMARY KEY, 
    Name TEXT, Price INT)";
cmd.ExecuteNonQuery();```
A Cars table is created. The INTEGER PRIMARY KEY column is autoincremented in SQLite.
``` sql
cmd.CommandText = "INSERT INTO Cars VALUES(1,'Audi',52642)";
cmd.ExecuteNonQuery();
cmd.CommandText = "INSERT INTO Cars VALUES(2,'Mercedes',57127)";
cmd.ExecuteNonQuery();
```
We insert two rows into the table.
```
sqlite> .mode column  
sqlite> .headers on
```
In the sqlite3 command line tool we modify the way the data is displayed in the console. We use the column mode and turn on the headers.
``` sql
sqlite> SELECT * FROM Cars;
Id          Name        Price     
----------  ----------  ----------
1           Audi        52642     
2           Mercedes    57127     
3           Skoda       9000      
4           Volvo       29000     
5           Bentley     350000    
6           Citroen     21000     
7           Hummer      41400     
8           Volkswagen  21600     
```
We verify the data. The Cars table was successfully created.

## Prepared statements
Now we will concern ourselves with prepared statements. When we write prepared statements, we use placeholders instead of directly writing the values into the statements. Prepared statements increase security and performance.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {

        string cs = "URI=file:test.db";

        using(SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            using (SqliteCommand cmd = new SqliteCommand(con)) 
            {
                cmd.CommandText = "INSERT INTO Cars(Name, Price) VALUES(@Name, @Price)";
                cmd.Prepare();
                
                cmd.Parameters.AddWithValue("@Name", "BMW");
                cmd.Parameters.AddWithValue("@Price", 36600);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }
    }
}
```
We add a row to the Cars table. We use a parameterized command.
```
cmd.CommandText = "INSERT INTO Cars(Name, Price) VALUES(@Name, @Price)";
cmd.Prepare();
```
Here we create a prepared statement. When we write prepared statements, we use placeholders instead of directly writing the values into the statements. Prepared statements are faster and guard against SQL injection attacks. The @Name and @Price are placeholders, which are going to be filled later.
```
cmd.Parameters.AddWithValue("@Name", "BMW");
cmd.Parameters.AddWithValue("@Price", 36600);
```

Values are bound to the placeholders.
```
cmd.ExecuteNonQuery();
```
The prepared statement is executed. We use the ExecuteNonQuery() method of the SqliteCommand object when we do not expect any data to be returned.
``` sql
$ mono prepared.exe 

sqlite> SELECT * FROM Cars;
Id          Name        Price     
----------  ----------  ----------
1           Audi        52642     
2           Mercedes    57127     
3           Skoda       9000      
4           Volvo       29000     
5           Bentley     350000    
6           Citroen     21000     
7           Hummer      41400     
8           Volkswagen  21600     
9           BMW         36600  
```
We have a new car inserted into the table.



## ADO.NET DataSet
The ADO.NET architecture consists of two central parts. The .NET Data Providers and the DataSet. The data providers are components that have been explicitly designed for data manipulation and fast access to data. The DataSet is created for data access independent of any data source. It can be used with multiple and differing data sources, with XML data, or used to manage data local to the application.

 
> A DataSet is a copy of the data and the relations among the data from the database tables. It is created in memory and used when extensive processing on data is needed or when we bind data tables to a Winforms control. When the processing is done, the changes are written to the data source. The DataSet is a disconnected relational structure. This means that the underlying connection does not have to be open during the entire life of a DataSet object. This enables us to use efficiently our available database connections.

A DataSet can be populated in a variety of ways. We can use the Fill() method of the SqliteDataAdapter class. We can create programmatically the DataTable, DataColumn, and DataRow objects. Data can be read from an XML document or from a stream.

A SqliteDataAdapter is an intermediary between the DataSet and the data source. It populates a DataSet and resolves updates with the data source. A DataTable is a representation of a database table in a memory. One or more data tables may be added to a data set. The changes made to the DataSet are saved to data source by the SqliteCommandBuilder class.

The DataGridView control provides a customisable table for displaying data. It allows customisation of cells, rows, columns, and borders through the use of properties. We can use this control to display data with or without an underlying data source.

### Creating a DataTable
In the first example, we will work with the DataTable class.
```
sqlite> CREATE TABLE Friends2(Id INTEGER PRIMARY KEY, Name TEXT);
```
In this case, the table must be created before we can save any data into it.

```csharp
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";

        using( SqliteConnection con = new SqliteConnection(cs))
        {

            con.Open();

            DataTable table = new DataTable("Friends2");

            DataColumn column;
            DataRow row;
 
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Id";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            table.Columns.Add(column);

            row = table.NewRow();
            row["Id"] = 1;
            row["Name"] = "Jane";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Id"] = 2;
            row["Name"] = "Lucy";
            table.Rows.Add(row);

            row = table.NewRow();
            row["Id"] = 3;
            row["Name"] = "Thomas";
            table.Rows.Add(row);

            string sql = "SELECT * FROM Friends2";

            using (SqliteDataAdapter da = new SqliteDataAdapter(sql, con))
            {
                using (new SqliteCommandBuilder(da))
                {
                    da.Fill(table);
                    da.Update(table);
                }
            }
    
            con.Close();
        }
    }
}
```
In the example, we create a new DataTable object. We add two columns and three rows to the table. Then we save the data in a new Friends2 database table.
```
DataTable table = new DataTable("Friends2");
```
A new DataTable object is created.
```
column = new DataColumn();
column.DataType = System.Type.GetType("System.Int32");
column.ColumnName = "Id";
table.Columns.Add(column);
```
A new column is added to the table. We provide a data type and name for the column. The columns of a DataTable are accessed via the Columns property.
```
row = table.NewRow();
row["Id"] = 1;
row["Name"] = "Jane";
table.Rows.Add(row);
```
A row is added to the table. The rows of a DataTable are accessed via the Rows property.
```
string sql = "SELECT * FROM Friends2";

using (SqliteDataAdapter da = new SqliteDataAdapter(sql, con))
```
The SqliteDataAdapter is an intermediary between the database table and its representation in the memory.
```
using (new SqliteCommandBuilder(da))
```
The SqliteCommandBuilder wraps the data adapter. It only needs to be instantiated. We do not work with it directly later.
```
da.Fill(table);
da.Update(table);
```
The data adapter is filled with the data from the table. The Update method inserts the data to the database.

### Saving XML data
Data from the DataTable can be easily saved in an XML file. There is a WriteXml() method for this task.
``` csharp
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";      

        using (SqliteConnection con = new SqliteConnection(cs))
        {        
            con.Open();

            string stm = "SELECT * FROM Cars LIMIT 5";

            using (SqliteDataAdapter da = new SqliteDataAdapter(stm, con))
            {
                DataSet ds = new DataSet();
                
                da.Fill(ds, "Cars");
                DataTable dt = ds.Tables["Cars"];

                dt.WriteXml("cars.xml");

                foreach (DataRow row in dt.Rows) 
                {            
                    foreach (DataColumn col in dt.Columns) 
                    {
                        Console.Write(row[col] + " ");
                    }
                    
                    Console.WriteLine();
                }
            }

            con.Close();
        }
    }
}
```
We print 5 cars from the Cars table. We also save them in an XML file.
```
using (SqliteDataAdapter da = new SqliteDataAdapter(stm, con))
```
A SqliteDataAdapter object is created. It takes an SQL statement and a connection as parameters. The SQL statement will be used to retrieve and pass the data by the SqliteDataAdapter.
```
DataSet ds = new DataSet();

da.Fill(ds, "Cars");
```

We create the DataSet object. The Fill() method uses the data adapter to retrieve the data from the data source. It creates a new DataTable named Cars and fills it with the retrieved data.
```
DataTable dt = ds.Tables["Cars"];
```

The Tables property provides us with the collection of data tables contained in the DataSet. From this collection we retrieve the Cars DataTable.
```
dt.WriteXml("cars.xml");
```

We write the data from the data table to an XML file.
```
foreach (DataRow row in dt.Rows) 
{            
    foreach (DataColumn col in dt.Columns) 
    {
        Console.Write(row[col] + " ");
    }
    
    Console.WriteLine();
}
```
We display the contents of the Cars table to the terminal. To traverse the data, we utilise the rows and columns of the DataTable object.
```
$ dmcs savexml.cs -r:Mono.Data.Sqlite.dll -r:System.Data.dll
```
To compile the example, we add an additional DLL file System.Data.dll.

### Loading XML data
We have shown how to save data in XML files. Now we are going to show, how to load the data from an XML file.
``` csharp
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";      

        using (SqliteConnection con = new SqliteConnection(cs))
        {        
            con.Open();

            DataSet ds = new DataSet();
            
            ds.ReadXml("cars.xml");
            DataTable dt = ds.Tables["Cars"];

            foreach (DataRow row in dt.Rows) 
            {            
                foreach (DataColumn col in dt.Columns) 
                {
                  Console.Write(row[col] + " ");
                }                
                 
                Console.WriteLine();
            }                         

            con.Close();
        }
    }
}
```
We read the contents of the cars.xml file into the DataSet. We print all the rows to the terminal.
```
DataSet ds = new DataSet();
```
A DataSet object is created.
```
ds.ReadXml("cars.xml");
```

The data from the cars.xml is read into the data set.
```
DataTable dt = ds.Tables["Cars"];
```

When the data was read into the data set a new DataTable was created. We get this table.
```
foreach (DataRow row in dt.Rows) 
{            
    foreach (DataColumn col in dt.Columns) 
    {
        Console.Write(row[col] + " ");
    }                
        
    Console.WriteLine();
}    
```
We print all the rows of the data table.
```
$ mono loadxml.exe 
1 Audi 52642 
2 Mercedes 57127 
3 Skoda 9000 
4 Volvo 29000 
5 Bentley 350000 
```

Running the example.

### DataGridView
In the next example, we are going to bind a table to a Winforms DataGridView control.
``` csharp
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using Mono.Data.Sqlite;

class MForm : Form
{

    private DataGridView dgv = null;      
    private DataSet ds = null;

    public MForm()
    {

       this.Text = "DataGridView";
       this.Size = new Size(450, 350);
       
       this.InitUI();
       this.InitData();
       
       this.CenterToScreen();
    }
    
    void InitUI()
    {    
        dgv = new DataGridView();

        dgv.Location = new Point(8, 0);
        dgv.Size = new Size(350, 300);
        dgv.TabIndex = 0;
        dgv.Parent = this;        
    }

    void InitData()
    {    
        string cs = "URI=file:test.db";

        string stm = "SELECT * FROM Cars";

        using (SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            ds = new DataSet();

            using (SqliteDataAdapter da = new SqliteDataAdapter(stm, con))
            {
                da.Fill(ds, "Cars");                  
                dgv.DataSource = ds.Tables["Cars"];
            }
            
            con.Close();
        }     
    }
}

class MApplication 
{
    public static void Main() 
    {
        Application.Run(new MForm());
    }
}
```

In this example, we bind the Cars table to the Winforms DataGridView control.
```
using System.Windows.Forms;
using System.Drawing;
```

These two namespaces are for the GUI.
```
this.InitUI();
this.InitData();
```

Inside the InitUI() method, we build the user interface. In the InitData() method, we connect to the database, retrieve the data into the DataSet and bind it to the DataGrid control.
```
dgv = new DataGridView();
```
The DataGridView control is created.
```
string stm = "SELECT * FROM Cars";
```
We will display the data from the Cars table in the DataGridView control.
```
dgv.DataSource = ds.Tables["Cars"];
```
We bind the DataSource property of the DataGridView control to the chosen table.
```
$ dmcs datagridview.cs -r:System.Data.dll -r:System.Drawing.dll 
    -r:Mono.Data.Sqlite.dll -r:System.Windows.Forms.dll
```

To compile the example, we must include additional DLLs. The DLL for SQLite data provider, for the Winforms, Drawing, and for Data.


## Working with images in SQLite with C#
In this chapter of the SQLite C# tutorial, we will work with image files. Note that some people oppose putting images into databases. Here we only show how to do it and we avoid the technical issues of whether to save images in databases or not.
```
sqlite> CREATE TABLE Images(Id INTEGER PRIMARY KEY, Data BLOB);
```
For this example, we create a new table called Images. For the images, we use the BLOB data type, which stands for Binary Large Object.

 
### Inserting images
In the first example, we are going to insert an image to the SQLite database.
``` csharp
using System;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;

public class Example
{
    static void Main() 
    {

        string cs = "URI=file:test.db";        

        using(SqliteConnection con = new SqliteConnection(cs))
        {
            
            con.Open();

            byte[] data = null;

            try
            {
                data = File.ReadAllBytes("woman.jpg");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
 
            SqliteCommand cmd = new SqliteCommand(con);
    
            cmd.CommandText = "INSERT INTO Images(Data) VALUES (@img)";
            cmd.Prepare();

            cmd.Parameters.Add("@img", DbType.Binary, data.Length);
            cmd.Parameters["@img"].Value = data;
            cmd.ExecuteNonQuery();
            
            con.Close();
        }
    }
}
```

We read an image from the current working directory and write it into the Images table of the SQLite test.db database.
```
byte[] data = null;
```

The image data will be stored in an array of bytes.
```
data = File.ReadAllBytes("woman.jpg");
```
The ReadAllBytes() method opens a binary file, reads the contents of the file into a byte array, and then closes the file.
```
cmd.CommandText = "INSERT INTO Images(Data) VALUES (@img)";
cmd.Prepare();
```
We prepare an SQL statement for inserting the array of bytes into the Data column of the Images table.
```
cmd.Parameters.Add("@img", DbType.Binary, data.Length);
cmd.Parameters["@img"].Value = data;
cmd.ExecuteNonQuery();
```
We bind the binary data to the prepared statement. Then the statement is executed. The image is written to the database table.

### Reading images
In this section, we are going to perform the reverse operation. We will read an image from the database table.
``` csharp
using System;
using System.IO;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";        

        using(SqliteConnection con = new SqliteConnection(cs))
        {            
            con.Open();

            SqliteCommand cmd = new SqliteCommand(con);   
            cmd.CommandText = "SELECT Data FROM Images WHERE Id=1";
            byte[] data = (byte[]) cmd.ExecuteScalar();

            try
            {               
                if (data != null)
                { 
                    File.WriteAllBytes("woman2.jpg", data);
                } else 
                {
                    Console.WriteLine("Binary data not read");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }            

            con.Close();
        }
    }
}
```
We read image data from the Images table and write it to another file, which we call woman2.jpg.
```
cmd.CommandText = "SELECT Data FROM Images WHERE Id=1";
```
This line selects the image data from the table.
```
byte[] data = (byte[]) cmd.ExecuteScalar();
```
We retrieve the binary data from the database table. The data is stored in an array of bytes.
```
if (data != null)
{ 
    File.WriteAllBytes("woman2.jpg", data);
} else 
{
    Console.WriteLine("Binary data not read");
}
```
The WriteAllBytes() method creates a new file, writes the specified byte array to the file, and then closes the file. If the target file already exists, it is overwritten. When the database table is empty and we run this example, we get a null. Therefore we check for the null value.

This part of the SQLite C# tutorial was dedicated to reading and writing images.


# Getting SQLite metadata with C#
Metadata is information about the data in the database. Metadata in SQLite contains information about the tables and columns, in which we store data. Number of rows affected by an SQL statement is metadata. Number of rows and columns returned in a result set belong to metadata as well.


 
Metadata in SQLite can be obtained using the PRAGMA command. SQLite objects may have attributes, which are metadata. Finally, we can also obtain specific metatada from querying the SQLite system sqlite_master table.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";

        string nrows = null;

        try {
            Console.Write("Enter rows to fetch: ");
            nrows = Console.ReadLine();
        } catch (FormatException e)
        {
            Console.WriteLine(e.ToString());
        }

        using (SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            using (SqliteCommand cmd = con.CreateCommand())
            {

                cmd.CommandText = "SELECT * FROM Cars LIMIT @Id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Id", Int32.Parse(nrows));

                int cols = 0;
                int rows = 0;

                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {

                    cols = rdr.FieldCount;
                    rows = 0;

                    while (rdr.Read()) 
                    {
                        rows++;
                    }

                    Console.WriteLine("The query fetched {0} rows", rows);
                    Console.WriteLine("Each row has {0} cols", cols);
                }    
            }

            con.Close();
        }
    }
}
```
In the above example, we get the number of rows and columns returned by a query.
```
try {
    Console.Write("Enter rows to fetch: ");
    nrows = Console.ReadLine();
} catch (FormatException e)
{
    Console.WriteLine(e.ToString());
}
```

The example asks for the number of rows on the command line.
```
cmd.CommandText = "SELECT * FROM Cars LIMIT @Id";
cmd.Prepare();
cmd.Parameters.AddWithValue("@Id", Int32.Parse(nrows));
```
We limit the selected rows to the number provided to the program.
```
cols = rdr.FieldCount;
```
The number of returned columns can be easily get from the FieldCount property of the SqliteDataReader object.
```
while (rdr.Read()) 
{
    rows++;
}
```
We count the number of rows in the result set.
```
$ mono fields_rows.exe 
Enter rows to fetch: 4
```
The query fetched 4 rows
Each row has 3 cols
Output.

### Column headers
This is how to print column headers with the data from a database table.
``` csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {

        string cs = "URI=file:test.db";

        using (SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            string stm = "SELECT * FROM Cars LIMIT 5";

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {

                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    Console.WriteLine(String.Format("{0, -3} {1, -8} {2, 8}", 
                        rdr.GetName(0), rdr.GetName(1), rdr.GetName(2)));

                    while (rdr.Read()) 
                    {
                        Console.WriteLine(String.Format("{0, -3} {1, -8} {2, 8}", 
                            rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2)));
                    }
                }
            }

            con.Close();
        }
    }
}
In this program, we select 5 rows from the Cars table with their column names.

using (SqliteDataReader rdr = cmd.ExecuteReader())
We create a SqliteDataReader object.

Console.WriteLine(String.Format("{0, -3} {1, -8} {2, 8}", 
    rdr.GetName(0), rdr.GetName(1), rdr.GetName(2)));
We get the names of the columns with the GetName() method of the reader. The String.Format() method is used to format the data.

while (rdr.Read()) 
{
    Console.WriteLine(String.Format("{0, -3} {1, -8} {2, 8}", 
        rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2)));
}       
We print the data that was returned by the SQL statement to the terminal.

$ dmcs columns.cs -r:Mono.Data.Sqlite.dll
$ mono columns.exe 
Id  Name        Price
1   Audi        52642
2   Mercedes    57127
3   Skoda        9000
4   Volvo       29000
5   Bentley    350000
Ouput of the program.
```
Affected rows
In the following example, we will find out how many changes have been done by a particular SQL command.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "Data Source=:memory:";

        using (SqliteConnection con = new SqliteConnection(cs))
        {

            con.Open();

            using (SqliteCommand cmd = new SqliteCommand(con))
            {
                cmd.CommandText = "CREATE TABLE Friends(Id INT, Name TEXT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends VALUES(1, 'Tom')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends VALUES(2, 'Jane')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends VALUES(3, 'Rebekka')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends VALUES(4, 'Lucy')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends VALUES(5, 'Robert')";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "DELETE FROM Friends WHERE Id IN (3, 4, 5)";
                int n = cmd.ExecuteNonQuery();

                Console.WriteLine("The statement has affected {0} rows", n);
                
           }

           con.Close();
        }
    }
}
```
We create a Friends table in memory. In the last SQL command, we delete three rows. The ExecuteNonQuery() method returns the number of rows affected by the last SQL command.
```
cmd.CommandText = "DELETE FROM Friends WHERE Id IN (3, 4, 5)";
```
In this SQL statement, we delete three rows.
```
int n = cmd.ExecuteNonQuery();
```
We find out the number of changes done by the last SQL statement.
```
$ mono affected.exe 
```


### Table schema
There is a GetSchemaTable() method which returns metadata about each column. It returns many values, among others the column name, column size, the base table name or whether the column is unique or not.
``` csharp
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";

        using(SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();

            string stm = "SELECT * FROM Cars LIMIT 3";   

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {

                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    DataTable schemaTable = rdr.GetSchemaTable();

                    foreach (DataRow row in schemaTable.Rows)
                    {
                        foreach (DataColumn col in schemaTable.Columns)
                            Console.WriteLine(col.ColumnName + " = " + row[col]);
                        Console.WriteLine();
                    }
                }
            }

            con.Close();
         }
    }
}
```
The example prints lots of metadata about table columns.
```
DataTable schemaTable = rdr.GetSchemaTable();
```
We get the schema table.
```
foreach (DataRow row in schemaTable.Rows)
{
    foreach (DataColumn col in schemaTable.Columns)
        Console.WriteLine(col.ColumnName + " = " + row[col]);
    Console.WriteLine();
}
```
We go through the schema table rows, which hold the metadata, and print them to the console.
```
$ dmcs schema.cs -r:Mono.Data.Sqlite.dll -r:System.Data.dll
$ mono schema.exe 
ColumnName = Id
ColumnOrdinal = 0
ColumnSize = 8
NumericPrecision = 19
NumericScale = 0
IsUnique = True
IsKey = True
...
Excerpt from the example output.
```
Table names
In our last example related to the metadata, we will list all tables in the test.db database.
``` csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";

        using (SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();

            string stm = @"SELECT name FROM sqlite_master
                WHERE type='table' ORDER BY name";   

            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read()) 
                    {
                        Console.WriteLine(rdr.GetString(0));
                    }
                }
            }    
            
            con.Close();    
        }
    }
}
```
The code example prints all available tables in the chosen database to the terminal.

string stm = @"SELECT name FROM sqlite_master
    WHERE type='table' ORDER BY name"; 
The table names are retrieved from the sqlite_master table.
```
$ mono tables.exe 
Cars
Friends
Images
These were the tables on our system.
```
In this part of the SQLite C# tutorial, we have worked with database metadata.



## SQLite transactions with C#
 
> A transaction is an atomic unit of database operations against the data in one or more databases. The effects of all the SQL statements in a transaction can be either all committed to the database or all rolled back.

In SQLite, any command other than the SELECT will start an implicit transaction. Also, within a transaction a command like CREATE TABL ..., VACUUM, PRAGMA, will commit previous changes before executing.

Manual transactions are started with the BEGIN TRANSACTION statement and finished with the COMMIT or ROLLBACK statements.

SQLite supports three non-standard transaction levels: DEFERRED, IMMEDIATE, and EXCLUSIVE. SQLite automatically puts each command into its own transaction unless we start our own transaction. Note that this may be influenced by the driver too. SQLite Python driver has the autocommit mode turned off by default and the first SQL command starts a new transaction.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";        
        
        using (SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();

            using (SqliteCommand cmd = con.CreateCommand())
            {
                cmd.CommandText = "DROP TABLE IF EXISTS Friends";
                cmd.ExecuteNonQuery();
                cmd.CommandText = @"CREATE TABLE Friends(Id INTEGER PRIMARY KEY, 
                                    Name TEXT)";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Tom')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Rebecca')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Jim')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Robert')";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Julian')";
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
    }
}
```
We create a Friends table and fill it with data. We do not explicitly start a transaction, nor we call commit or rollback methods. Yet the data is written to the table. It is because by default, we work in the autocommit mode. In this mode each SQL statement is immediately effective.
```
cmd.CommandText = "DROP TABLE IF EXISTS Friends";
cmd.ExecuteNonQuery();
cmd.CommandText = @"CREATE TABLE Friends(Id INTEGER PRIMARY KEY, 
                    Name TEXT)";
cmd.ExecuteNonQuery();
```
We drop the Friends table if it already exists. Then we create the table with the CREATE TABLE statement.
```
cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Tom')";
cmd.ExecuteNonQuery();
cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Rebecca')";
cmd.ExecuteNonQuery();
...
```
We insert two rows.
```
sqlite> SELECT * FROM Friends;
1|Tom
2|Rebecca
3|Jim
4|Robert
5|Julian
```
The Friends table was successfully created.

In the second example we will start a custom transaction with the BeginTransaction() method.
``` csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";        
        
        using (SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();

            using(SqliteTransaction tr = con.BeginTransaction())
            {
                using (SqliteCommand cmd = con.CreateCommand())
                {

                    cmd.Transaction = tr;
                    cmd.CommandText = "DROP TABLE IF EXISTS Friends";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = @"CREATE TABLE Friends(Id INTEGER PRIMARY KEY, 
                                        Name TEXT)";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Tom')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Rebecca')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Jim')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Robert')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Julian')";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Jane')";
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
            }

            con.Close();
        }
    }
}
```
All SQL commands form a unit. Either all are saved or nothing is saved. This is the basic idea behind transactions.
```
using(SqliteTransaction tr = con.BeginTransaction())
```
The BeginTransaction() method starts a transaction.
```
cmd.Transaction = tr;
```
We set the transaction within which the SqliteCommand executes.
```
tr.Commit();
```
If everything ran OK, we commit the whole transaction to the database. In case of an exception, the transaction is rolled back behind the scenes.

## Explicit rollback call
Now we are going to show an example, where we rollback manually a transaction, in case of an exception.
```csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";   

        SqliteConnection con = null;     
        SqliteTransaction tr = null;
        SqliteCommand cmd = null;
        
        try 
        {
            con = new SqliteConnection(cs);
        
            con.Open();
    
            tr = con.BeginTransaction();
            cmd = con.CreateCommand();
                
            cmd.Transaction = tr;
            cmd.CommandText = "DROP TABLE IF EXISTS Friends";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE Friends(Id INTEGER PRIMARY KEY, 
                                Name TEXT)";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Tom')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Rebecca')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Jim')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Robert')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Julian')";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "INSERT INTO Friends(Name) VALUES ('Jane')";
            cmd.ExecuteNonQuery();
                
            tr.Commit();            

        } catch (SqliteException ex) 
        {
            Console.WriteLine("Error: {0}",  ex.ToString());

            if (tr != null)
            {
                try 
                {
                    tr.Rollback();
                    
                } catch (SqliteException ex2)
                {

                    Console.WriteLine("Transaction rollback failed.");
                    Console.WriteLine("Error: {0}",  ex2.ToString());

                } finally
                {
                    tr.Dispose();
                }
            }
        } finally 
        {
            if (cmd != null)
            {
                cmd.Dispose();
            }

            if (tr != null) 
            {
                tr.Dispose();
            }

            if (con != null)
            {
                try 
                {
                    con.Close();                    

                } catch (SqliteException ex)
                {

                    Console.WriteLine("Closing connection failed.");
                    Console.WriteLine("Error: {0}",  ex.ToString());

                } finally
                {
                    con.Dispose();
                }
            }
        }    
    }
}
```
We create our own try, catch, finally blocks, where we deal with possible issues.
```
} catch (SqliteException ex) 
{
    Console.WriteLine("Error: {0}",  ex.ToString());

    if (tr != null)
    {
        try 
        {
            tr.Rollback();
            
        } catch (SqliteException ex2)
        {

            Console.WriteLine("Transaction rollback failed.");
            Console.WriteLine("Error: {0}",  ex2.ToString());

        } finally
        {
            tr.Dispose();
        }
    }
}
```
When an exception was thrown during the creation of the Friends table, we call the Rollback() method. Even when doing rollback, there might occur an exception. So we check this scenario also.
```
if (cmd != null)
{
    cmd.Dispose();
}

if (tr != null) 
{
    tr.Dispose();
}

```
When all goes OK, we dispose the resources.
```
if (con != null)
{
    try 
    {
        con.Close();                    

    } catch (SqliteException ex)
    {

        Console.WriteLine("Closing connection failed.");
        Console.WriteLine("Error: {0}",  ex.ToString());

    } finally
    {
        con.Dispose();
    }
}
```
When closing a connection, we might receive another exception. We handle this case here.

Errors
When there is an error in the transaction, the transaction is rolled back an no changes are committed to the database.
``` csharp
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";        
        
        using (SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();

            using(SqliteTransaction tr = con.BeginTransaction())
            {
                using (SqliteCommand cmd = con.CreateCommand())
                {

                    cmd.Transaction = tr;
                    cmd.CommandText = "UPDATE Friends SET Name='Thomas' WHERE Id=1";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "UPDATE Friend SET Name='Bob' WHERE Id=4";
                    cmd.ExecuteNonQuery();
                }

                tr.Commit();
            }

            con.Close();
        }
    }
}
```

In the code example we want to change two names. There are two statements which form a transaction. There is an error in the second SQL statement. Therefore the transaction is rolled back.
```
cmd.CommandText = "UPDATE Friend SET Name='Bob' WHERE Id=4";
```
The name of the table is incorrect. There is no Friend table in the database.
```
$ mono trans_error.exe 
```

Unhandled Exception: Mono.Data.Sqlite.SqliteException: SQLite error
no such table: Friend
...
Running the example will display this error message. The transaction is rolled back.
``` sql
sqlite> SELECT * FROM Friends;
1|Tom
2|Rebecca
3|Jim
4|Robert
5|Julian
6|Jane
```
No changes took place in the Friends table. Even if the first UPDATE statement was correct.

We will again try to change two rows; this time without using the SqliteTransaction.
```
using System;
using Mono.Data.Sqlite;

public class Example
{

    static void Main() 
    {
        string cs = "URI=file:test.db";        
        
        using (SqliteConnection con = new SqliteConnection(cs)) 
        {
            con.Open();

            using (SqliteCommand cmd = con.CreateCommand())
            {

                cmd.CommandText = "UPDATE Friends SET Name='Thomas' WHERE Id=1";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "UPDATE Friend SET Name='Bob' WHERE Id=4";
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }
    }
}
```
We try to update two names in the Friends table, Tom to Thomas and Robert to Bob.
```
cmd.CommandText = "UPDATE Friend SET Name='Bob' WHERE Id=4";
cmd.ExecuteNonQuery();
```
This UPDATE statement is incorrect.
```
$ mono notrans_error.exe 

Unhandled Exception: Mono.Data.Sqlite.SqliteException: SQLite error
no such table: Friend
```
We receive the same error message as in the previous example.
```sql
sqlite> SELECT * FROM Friends;
1|Thomas
2|Rebecca
3|Jim
4|Robert
5|Julian
6|Jane
```
However this time, the first UPDATE statement was saved. The second one was not.






