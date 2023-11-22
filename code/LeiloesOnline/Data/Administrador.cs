namespace LeiloesOnline.Data

{
    public class Administrador
    {
        public string email_administrador { get; set; } = "";
        public string username { get; set; } = "";
        public string admi_password { get; set; } = "";
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
