CREATE TABLE `tblProduto` (
    Id INT PRIMARY KEY auto_increment,
    Nome     VARCHAR (250) NOT NULL,
    Descricao VARCHAR (250) NOT NULL,
    Ativo  BIT  NOT NULL,
    Perecivel BIT NOT NULL,
    CategoriaID INT NOT NULL,
    CONSTRAINT `fk_CategoriaID` FOREIGN KEY ( `CategoriaID` ) REFERENCES `tblCategoriaProduto` ( `Id` )
) ENGINE = innodb;

INSERT INTO `produtostore`.`tblproduto`
(`Nome`,`Descricao`,`Ativo`,`Perecivel`,`CategoriaID`)
VALUES
("TV LG Smart" , "TV LG Smart 100 pol" , true , false , 1);

SELECT `tblproduto`.`Nome`, `tblproduto`.`Descricao`,`tblproduto`.`Ativo`,`tblproduto`.`Perecivel`, `tblproduto`.`CategoriaId`, `tblcategoriaproduto`.`Nome`,
 `tblcategoriaproduto`.`Descricao`, `tblcategoriaproduto`.`Ativo`
  FROM `produtostore`.`tblproduto` INNER JOIN 
 `produtostore`.`tblcategoriaproduto` on tblcategoriaproduto.Id = tblproduto.CategoriaID;


SELECT * FROM `produtostore`.`tblproduto` INNER JOIN 
 `produtostore`.`tblcategoriaproduto` on tblcategoriaproduto.Id = tblproduto.CategoriaID
WHERE tblproduto.Id = 1;

UPDATE `produtostore`.`tblproduto`
SET
`Nome` = "Pen drive",
`Descricao` = "Pen drive 8gb",
`Ativo` = true,
`Perecivel` = false,
`CategoriaID` = 2
WHERE `Id` = 1;

DELETE FROM `produtostore`.`tblproduto`
WHERE Id = 1;


CREATE TABLE `tblCategoriaProduto` (
	Id INT PRIMARY KEY,
    Nome     VARCHAR (250) NOT NULL,
    Descricao VARCHAR (250) NOT NULL,
     Ativo  BIT  NULL
     ) ENGINE = innodb;
     
INSERT INTO `produtostore`.`tblcategoriaproduto`
(`Id`,`Nome`,`Descricao`,`Ativo`)
VALUES ((5)  ,("Livros")  ,("Livros") ,(true));




