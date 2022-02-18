// See https://aka.ms/new-console-template for more information

using Emb;
using Raven.Embedded;

Console.WriteLine("Hello, World!");

//EmbeddedServer.Instance.StartServer();
EmbeddedServer.Instance.StartServer(new ServerOptions
{
    DataDirectory = "C:\\RavenData",
    ServerUrl = "http://127.0.0.1:8090"
});


using (var store = EmbeddedServer.Instance.GetDocumentStore("Embedded"))
{
    using (var session = store.OpenSession())
    {
        session.Store(new User
        {
            Name = "Jane Smith"
        });

        session.SaveChanges();
    }

    Console.ReadLine();
}