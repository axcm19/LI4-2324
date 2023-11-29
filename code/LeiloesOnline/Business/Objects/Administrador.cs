namespace LeiloesOnline.Business.Objects

{
    public class Administrador
    {
        // Atributos do administrador
        private string email_administrador { get; set; }
        private string username { get; set; }
        private string admi_password { get; set; }

        public Administrador()
        {
            email_administrador = "";
            username = "";
            admi_password = "";
        }

        public Administrador(string email, string username, string pass)
        {
            email_administrador = email;
            this.username = username;
            admi_password = pass;
        }

        public Administrador(Administrador ad)
        {
            email_administrador = ad.email_administrador;
            username = ad.username;
            admi_password = ad.admi_password;
        }

        public Administrador Clone()
        {
            Administrador result = new Administrador(this);
            return result;
        }
    }
}

/*
 CREATE TABLE Administrador(
	email_administrador VARCHAR(45) NOT NULL,
	username VARCHAR(45),
	admi_password VARCHAR(45),
	PRIMARY KEY(email_administrador)
);
 */
