using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using DemoUtils;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.Schema;

namespace LinqToXmlDemo
{
    #region Shared classes
    class Person
    {
        public int Id { get; set; }
        public int WorkplaceId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} Name:{1}", Id, Name);
        }
    }

    class Workplace
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return string.Format("Id:{0} Title:{1}", Id, Title);
        }
    }
    #endregion

    class Program
    {
        static XDocument xml;

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>()
            {
                new Person() { Id = 1, Name = "Homer", WorkplaceId = 1 },
                new Person() { Id = 2, Name = "Marge", WorkplaceId = 2 },
                new Person() { Id = 3, Name = "Bart", WorkplaceId = 3 },
                new Person() { Id = 4, Name = "Lisa", WorkplaceId = 3 },
                new Person() { Id = 5, Name = "Maggie", WorkplaceId = 2 }
            };

            List<Workplace> workplaces = new List<Workplace>()
            {
                new Workplace() { Id = 1, Title = "Powerplant" },
                new Workplace() { Id = 2, Title = "Home" },
                new Workplace() { Id = 3, Title = "School" }
            };

            // Loops through the list of persons and workplaces and creates the corresponding XML
            xml = new XDocument(
                new XElement("Persons",
                    from p in persons
                    join w in workplaces on p.WorkplaceId equals w.Id
                    select new XElement("Person",
                        new XAttribute("Id", p.Id),
                        new XAttribute("Name", p.Name),
                        new XElement("Workplace", w.Title)
                        )
                    )
                );

            Console.WriteLine(xml);

            //CreateXml();
            //QueryingXml();
            //PersistingXml();
            //UpdatingXml();
            //DeletingXml();
            //TransformingXmlUsingXslt();
            //TransformingXmlUsingLinq();
            //InferSchemaFromXml();
            //ValidateXmlAgainstScema();
        }

        static void CreateXml()
        {
            Print.Header();

            // Uses "functional construction" to create XML
            XDocument xml = new XDocument(
                new XElement("Persons",
                    new XElement("Person",
                        new XAttribute("Id", 1),
                        new XAttribute("Name", "Homer"),
                        new XElement("Workplace", "Poweplant")),
                    new XElement("Person",
                        new XAttribute("Id", 2),
                        new XAttribute("Name", "Marge"),
                        new XElement("Workplace", "Home"))
                    )
                );

            Console.WriteLine(xml);
        }

        static void QueryingXml()
        {
            Print.Header();

            // Gets all persons
            var persons = xml.Element("Persons").Elements("Person");
            persons.Print();

            Print.Divider("School persons");

            // Gets all persons with the workplace "School"
            var schoolPeople = xml.Element("Persons").Elements("Person").
                Where(e => e.Element("Workplace").Value == "School");
            schoolPeople.Print();

            Print.Divider("Person names");

            // Gets all the names of the persons
            var names = xml.Element("Persons").Elements("Person").Attributes("Name");
            names.Print(n => n.Value);

            Print.Divider("Bart");

            // Gets the person named "Bart"
            string bart = xml.Elements("Persons").Elements("Person").Attributes("Name").
                Where(a => a.Value == "Bart").Single().Value;

            Console.WriteLine(bart);
        }

        static void PersistingXml()
        {
            Print.Header();

            // Save the XML document
            xml.Save("Persons.xml");

            // Load the XML document
            xml = XDocument.Load("Persons.xml");

            Console.WriteLine(xml);

            Print.Divider();

            // Construct an XML string
            string myXml = "<Employees><Employee Name='Yada' /></Employees>";

            // Convert the string to "real" XML
            XElement element = XElement.Parse(myXml);

            Console.WriteLine(element);
        }

        static void UpdatingXml()
        {
            Print.Header();

            XDocument myXml = XDocument.Parse(xml.ToString());

            // Add a new person
            myXml.Element("Persons").Add(new XElement("Person", new XAttribute("Name", "Snowball")));
            Console.WriteLine(myXml);

            Print.Divider("Changing a name");

            // Change a name
            XAttribute attribute = myXml.Element("Persons").Elements("Person").Where(
                e => e.Attribute("Name").Value == "Marge").Single().Attribute("Name");

            attribute.Value = "Marjorie";

            Console.WriteLine(myXml);

            Print.Divider("Changing all names");

            // Change all names
            var nameAttributes = myXml.Element("Persons").Elements("Person").Attributes("Name");
            
            foreach (var nameAttribute in nameAttributes)
                nameAttribute.Value += " Simpson";

            Console.WriteLine(myXml);
        }

        static void DeletingXml()
        {
            Print.Header();

            XDocument myXml = XDocument.Parse(xml.ToString());

            // Delete a person
            myXml.Element("Persons").Elements().Where(
                e => e.Attribute("Name").Value == "Lisa").Single().Remove();

            Console.WriteLine(myXml);

            Print.Divider("Remove all persons");

            // Delete all persons
            myXml.Element("Persons").RemoveAll();

            Console.WriteLine(myXml);
        }

        static void TransformingXmlUsingXslt()
        {
            Print.Header();

            string xsl =
                @"<xsl:stylesheet version='1.0' xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
                      <xsl:template match='//Persons'>
                          <html>
                              <body>
                              <h1>Persons</h1>
                              <table>
                                  <tr align='left'>
                                      <th>Id</th>
                                      <th>Name</th>
                                  </tr>
                                  <xsl:apply-templates></xsl:apply-templates>
                              </table>
                              </body>
                          </html>
                      </xsl:template>
                      <xsl:template match='Person'>
                          <tr>
                              <td><xsl:value-of select='@Id'/></td>
                              <td><xsl:value-of select='@Name'/></td>
                          </tr>
                      </xsl:template>
                    </xsl:stylesheet>";

            XDocument transformedDoc = new XDocument();
            using (XmlWriter writer = transformedDoc.CreateWriter())
            {
                // Create a transformation object
                XslCompiledTransform transform = new XslCompiledTransform();

                // Supply the XSL
                transform.Load(XmlReader.Create(new StringReader(xsl)));

                // Supply the XML
                transform.Transform(xml.CreateReader(), writer);
            }

            Console.WriteLine(transformedDoc);
        }

        static void TransformingXmlUsingLinq()
        {
            Print.Header();

            XDocument transformedDoc = new XDocument(
                new XElement("html",
                    new XElement("body",
                        new XElement("h1", "Persons"),
                        new XElement("ol",
                            from e in xml.Element("Persons").Elements("Person")
                            select new XElement("li", e.Attribute("Name").Value)
                        ))
                    )
                );

            Console.WriteLine(transformedDoc);
        }

        // Note that this method doesn't use the LINQ To XML API since
        // no inference capabilities were added to it
        static void InferSchemaFromXml()
        {
            Print.Header();

            // Save the XML to disk
            xml.Save("Persons.xml");

            // Infer the scema set from the XML file
            XmlSchemaSet schemaSet = new XmlSchemaInference().InferSchema(new XmlTextReader("Persons.xml"));

            // Iterate through all schemas in the set (only one in this case)
            // and write the result to the XSD file
            using (XmlWriter writer = XmlWriter.Create("Persons.xsd"))
            {
                foreach (XmlSchema schema in schemaSet.Schemas())
                    schema.Write(writer);
            }

            // Load the schema from disk
            XDocument scemaDocument = XDocument.Load("Persons.xsd");
            Console.WriteLine(scemaDocument);
        }

        static void ValidateXmlAgainstScema()
        {
            Print.Header();

            // Add a car element to the XML to provoke the validation to fail
            //xml.Element("Persons").Add(new XElement("Car"));

            // Ctrate an empty scema set
            XmlSchemaSet schemaSet = new XmlSchemaSet();

            // Add the schema file to the set
            schemaSet.Add(null, "Persons.xsd");

            try
            {
                // Try to validate (will throw an XmlSchemaValidationException
                // exception if failed
                xml.Validate(schemaSet, null);

                Console.WriteLine("Document validated successfully.");
            }
            catch (XmlSchemaValidationException ex)
            {
                Console.WriteLine("Exception occurred: {0}", ex.Message);
                Console.WriteLine("Document validated unsuccessfully.");
            }
        }
    }
}
