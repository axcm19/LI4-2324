CREATE TABLE Participante(
	email_participante VARCHAR(45) NOT NULL,
	username VARCHAR(45),
	morada VARCHAR(45),
	carteira FLOAT,
	user_password VARCHAR(45),
	cc INTEGER,
	nif INTEGER,
	PRIMARY KEY(email_participante)
);


CREATE TABLE Administrador(
	email_administrador VARCHAR(45) NOT NULL,
	username VARCHAR(45),
	admi_password VARCHAR(45),
	PRIMARY KEY(email_administrador)
);


CREATE TABLE Leilao(
	id_leilao INTEGER NOT NULL,
	categoria VARCHAR(45),
	nome VARCHAR(45),
	data_inicio DATE,
	data_fim DATE,
	preco_base FLOAT,
	valor_minimo_licitacao FLOAT,
	licitacao_atual FLOAT,
	aprovado BIT,
	fk_email_participante_propos VARCHAR(45) NOT NULL,
	PRIMARY KEY(id_leilao),
	FOREIGN KEY (fk_email_participante_propos) REFERENCES Participante(email_participante),
);


CREATE TABLE Licitacao(
	data_ocorreu DATE,
	valor FLOAT,
	fk_email_participante VARCHAR(45) NOT NULL,
	fk_id_leilao INTEGER NOT NULL,
	FOREIGN KEY (fk_email_participante) REFERENCES Participante(email_participante),
	FOREIGN KEY (fk_id_leilao) REFERENCES Leilao(id_leilao),
);


CREATE TABLE Artigo(
	id_artigo INTEGER NOT NULL,
	nome VARCHAR(45),
	descricao VARCHAR(45),
	comprovativo VARCHAR(45),
	is_livro BIT,
	is_joia BIT,
	is_quadro BIT,
	fk_email_participante_dono VARCHAR(45) NOT NULL
	PRIMARY KEY(id_artigo),
	FOREIGN KEY (fk_email_participante_dono) REFERENCES Participante(email_participante),
);

CREATE TABLE Joia(
	id_artigo INTEGER NOT NULL,
	material VARCHAR(45),
	tipo VARCHAR(45),
	pureza_material FLOAT,
	PRIMARY KEY (id_artigo),
	FOREIGN KEY (id_artigo) REFERENCES Artigo(id_artigo),	
);


CREATE TABLE Quadro(
	id_artigo INTEGER NOT NULL,
	titulo VARCHAR(45),
	nome_autor VARCHAR(45),
	ano INTEGER,
	dimensoes VARCHAR(45),
	PRIMARY KEY (id_artigo),
	FOREIGN KEY (id_artigo) REFERENCES Artigo(id_artigo),	
);


CREATE TABLE Livro(
	id_artigo INTEGER NOT NULL,
	titulo VARCHAR(45),
	nome_autor VARCHAR(45),
	ano_edicao INTEGER,
	editora VARCHAR(45),
	numero_paginas INTEGER,
	PRIMARY KEY (id_artigo),
	FOREIGN KEY (id_artigo) REFERENCES Artigo(id_artigo),
);

CREATE TABLE Lote_Artigos(
	fk_id_artigo INTEGER,
	fk_id_leilao INTEGER,
	FOREIGN KEY (fk_id_artigo) REFERENCES Artigo(id_artigo),
	FOREIGN KEY (fk_id_leilao) REFERENCES Leilao(id_leilao),
);


