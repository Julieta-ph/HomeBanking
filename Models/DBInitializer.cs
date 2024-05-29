namespace HomeBankingV9.Models
{
    public class DBInitializer
    {

        //funciones que no van a devolver datos, se utiliza void

        public static void Initialize(HomeBankingContext context)
        {
            if (!context.Clients.Any())
            {
                var clients = new Client[]
                {

                    new Client{FirstName="Victor", LastName="Coronado", Email = "vcoronado@gmail.com", Password="123456"},
                    new Client{FirstName="Juan", LastName="Perez", Email = "sdgsdgsg@gmail.com", Password="125676"},
                    new Client{FirstName="Laura", LastName="Gomez", Email = "sggdsgfjt@gmail.com", Password="123896"},
                    new Client{FirstName="Miranda", LastName="Gonzalez", Email = "hjlgjdhhdt@gmail.com", Password="643296"},
                    new Client{FirstName="María", LastName="Ramirez", Email = "bdsfgjgft@gmail.com", Password="832696"}

                };

                context.Clients.AddRange(clients);

                //Guardar cambios

                context.SaveChanges();

            }

            if (!context.Accounts.Any())
            {

                
                Client vicClient = context.Clients.FirstOrDefault(cl => cl.Email == "vcoronado@gmail.com");

                if (vicClient != null)
                {
                    var vicAccount = new Account[]
                    {
                        new Account{Number="VIN001",CreationDate=DateTime.Now,Balance=1000,ClientId=vicClient.Id},

                        new Account{Number="VIN002",CreationDate=DateTime.Now,Balance=2000,ClientId=vicClient.Id}
                   };

                    context.Accounts.AddRange(vicAccount);
                    context.SaveChanges();
                }


            }
        }
    }
}
