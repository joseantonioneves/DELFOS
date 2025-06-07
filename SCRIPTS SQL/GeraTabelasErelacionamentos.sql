-- Gerado por José Antonio das Neves Neto
--   em:        2022-11-02 10:10:01 BRT
--   site:      SQL Server 2012
--   tipo:      SQL Server 2012



CREATE TABLE AppPortifolio 
    (
     AppId BIGINT NOT NULL , 
     ApplicationName NVARCHAR (150) , 
     IsActive BIT 
    )
GO

ALTER TABLE AppPortifolio ADD CONSTRAINT AppPortifolio_PK PRIMARY KEY CLUSTERED (AppId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE BillModel 
    (
     BillId BIGINT NOT NULL , 
     Tipo NVARCHAR (3) , 
     UrlAPI NVARCHAR (255) 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , 'Tipo do meio de pagamento:

- Pix (PIX)
- CC (Cartão de Crédito)
- DEB (Cartão de Débito)
- BLT (Boleto)' , 'USER' , 'dbo' , 'TABLE' , 'BillModel' , 'COLUMN' , 'Tipo' 
GO

ALTER TABLE BillModel ADD CONSTRAINT BillModel_PK PRIMARY KEY CLUSTERED (BillId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE CityModel 
    (
     CityId BIGINT NOT NULL , 
     Name NVARCHAR (50) , 
     IBGE NVARCHAR (7) , 
     StateModel_StateId BIGINT NOT NULL 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , '	' , 'USER' , 'dbo' , 'TABLE' , 'CityModel' , 'COLUMN' , 'Name' 
GO

    


CREATE UNIQUE NONCLUSTERED INDEX 
    CityModel__IDX ON CityModel 
    ( 
     StateModel_StateId 
    ) 
GO

ALTER TABLE CityModel ADD CONSTRAINT CityModel_PK PRIMARY KEY CLUSTERED (CityId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE CountryModel 
    (
     CountryId BIGINT NOT NULL , 
     Name NVARCHAR (100) , 
     Codigo NVARCHAR (3) , 
     Fone NVARCHAR (4) , 
     ISO NVARCHAR (2) , 
     ISO3 NVARCHAR (3) , 
     NomeFormal NVARCHAR (150) 
    )
GO

ALTER TABLE CountryModel ADD CONSTRAINT CountryModel_PK PRIMARY KEY CLUSTERED (CountryId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE EnrollmentModel 
    (
     EnrollmentId BIGINT NOT NULL , 
     AppPortifolio_AppId BIGINT NOT NULL , 
     SignatureModel_SignatureId BIGINT NOT NULL , 
     UserModel_UserId BIGINT NOT NULL 
    )
GO 

    


CREATE UNIQUE NONCLUSTERED INDEX 
    EnrollmentModel__IDX ON EnrollmentModel 
    ( 
     AppPortifolio_AppId 
    ) 
GO 


CREATE UNIQUE NONCLUSTERED INDEX 
    EnrollmentModel__IDXv1 ON EnrollmentModel 
    ( 
     SignatureModel_SignatureId 
    ) 
GO

ALTER TABLE EnrollmentModel ADD CONSTRAINT EnrollmentModel_PK PRIMARY KEY CLUSTERED (EnrollmentId, UserModel_UserId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE OrganizationModel 
    (
     OrganizationId BIGINT NOT NULL , 
     Razao NVARCHAR (250) , 
     CNPJ NVARCHAR (15) NOT NULL , 
     IsActive BIT , 
     Address NVARCHAR (250) , 
     NumberAddr NVARCHAR (6) , 
     ZipCode NVARCHAR (8) , 
     District NVARCHAR (150) , 
     CreditCardNumber NVARCHAR (16) , 
     CV NVARCHAR (3) , 
     EmailContact NVARCHAR (255) , 
     CityModel_CityId BIGINT NOT NULL 
    )
GO 



EXEC sp_addextendedproperty 'MS_Description' , '																																								' , 'USER' , 'dbo' , 'TABLE' , 'OrganizationModel' , 'COLUMN' , 'Razao' 
GO



EXEC sp_addextendedproperty 'MS_Description' , 'código de verificação do cartão de crédito' , 'USER' , 'dbo' , 'TABLE' , 'OrganizationModel' , 'COLUMN' , 'CV' 
GO

    


CREATE UNIQUE NONCLUSTERED INDEX 
    OrganizationModel__IDX ON OrganizationModel 
    ( 
     CityModel_CityId 
    ) 
GO

ALTER TABLE OrganizationModel ADD CONSTRAINT OrganizationModel_PK PRIMARY KEY CLUSTERED (OrganizationId, CNPJ)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE RoleModel 
    (
     RoleId BIGINT NOT NULL , 
     RoleName NVARCHAR (100) 
    )
GO

ALTER TABLE RoleModel ADD CONSTRAINT RoleModel_PK PRIMARY KEY CLUSTERED (RoleId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE SignatureModel 
    (
     SignatureId BIGINT NOT NULL , 
     KeySignature NVARCHAR (128) , 
     IsActive BIT , 
     OrganizationModel_OrganizationId BIGINT NOT NULL , 
     BillModel_BillId BIGINT NOT NULL , 
     AppId BIGINT NOT NULL , 
     OrganizationModel_CNPJ NVARCHAR (15) NOT NULL 
    )
GO 

    


CREATE UNIQUE NONCLUSTERED INDEX 
    SignatureModel__IDX ON SignatureModel 
    ( 
     BillModel_BillId 
    ) 
GO 


CREATE UNIQUE NONCLUSTERED INDEX 
    SignatureModel__IDXv1 ON SignatureModel 
    ( 
     OrganizationModel_OrganizationId , 
     OrganizationModel_CNPJ 
    ) 
GO

ALTER TABLE SignatureModel ADD CONSTRAINT SignatureModel_PK PRIMARY KEY CLUSTERED (SignatureId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE StateModel 
    (
     StateId BIGINT NOT NULL , 
     Name NVARCHAR (50) , 
     UF NVARCHAR (2) , 
     IBGECode NVARCHAR (7) , 
     DDD NVARCHAR (3) , 
     CountryModel_CountryId BIGINT NOT NULL 
    )
GO 

    


CREATE UNIQUE NONCLUSTERED INDEX 
    StateModel__IDX ON StateModel 
    ( 
     CountryModel_CountryId 
    ) 
GO

ALTER TABLE StateModel ADD CONSTRAINT StateModel_PK PRIMARY KEY CLUSTERED (StateId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE UserLogin 
    (
     UserLoginId BIGINT NOT NULL , 
     CreateLogin DATETIME , 
     LogTime DATETIME , 
     AuthenticateResult BIT , 
     LOG NVARCHAR (255) , 
     UserModel_UserId BIGINT NOT NULL 
    )
GO

ALTER TABLE UserLogin ADD CONSTRAINT UserLogin_PK PRIMARY KEY CLUSTERED (UserLoginId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE UserModel 
    (
     UserId BIGINT NOT NULL , 
     UserName NVARCHAR (150) , 
     Password NVARCHAR (250) , 
     EmailAddress NVARCHAR (150) , 
     Role NVARCHAR (100) , 
     Surname NVARCHAR (150) , 
     GivenName NVARCHAR (150) , 
     IsActive BIT , 
     RoleModel_RoleId BIGINT NOT NULL 
    )
GO

ALTER TABLE UserModel ADD CONSTRAINT UserModel_PK PRIMARY KEY CLUSTERED (UserId)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

ALTER TABLE CityModel 
    ADD CONSTRAINT CityModel_StateModel_FK FOREIGN KEY 
    ( 
     StateModel_StateId
    ) 
    REFERENCES StateModel 
    ( 
     StateId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE EnrollmentModel 
    ADD CONSTRAINT EnrollmentModel_AppPortifolio_FK FOREIGN KEY 
    ( 
     AppPortifolio_AppId
    ) 
    REFERENCES AppPortifolio 
    ( 
     AppId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE EnrollmentModel 
    ADD CONSTRAINT EnrollmentModel_SignatureModel_FK FOREIGN KEY 
    ( 
     SignatureModel_SignatureId
    ) 
    REFERENCES SignatureModel 
    ( 
     SignatureId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE EnrollmentModel 
    ADD CONSTRAINT EnrollmentModel_UserModel_FK FOREIGN KEY 
    ( 
     UserModel_UserId
    ) 
    REFERENCES UserModel 
    ( 
     UserId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE OrganizationModel 
    ADD CONSTRAINT OrganizationModel_CityModel_FK FOREIGN KEY 
    ( 
     CityModel_CityId
    ) 
    REFERENCES CityModel 
    ( 
     CityId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE SignatureModel 
    ADD CONSTRAINT SignatureModel_BillModel_FK FOREIGN KEY 
    ( 
     BillModel_BillId
    ) 
    REFERENCES BillModel 
    ( 
     BillId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE SignatureModel 
    ADD CONSTRAINT SignatureModel_OrganizationModel_FK FOREIGN KEY 
    ( 
     OrganizationModel_OrganizationId, 
     OrganizationModel_CNPJ
    ) 
    REFERENCES OrganizationModel 
    ( 
     OrganizationId , 
     CNPJ 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE StateModel 
    ADD CONSTRAINT StateModel_CountryModel_FK FOREIGN KEY 
    ( 
     CountryModel_CountryId
    ) 
    REFERENCES CountryModel 
    ( 
     CountryId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE UserLogin 
    ADD CONSTRAINT UserLogin_UserModel_FK FOREIGN KEY 
    ( 
     UserModel_UserId
    ) 
    REFERENCES UserModel 
    ( 
     UserId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE UserModel 
    ADD CONSTRAINT UserModel_RoleModel_FK FOREIGN KEY 
    ( 
     RoleModel_RoleId
    ) 
    REFERENCES RoleModel 
    ( 
     RoleId 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



-- Relatório do Resumo do Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                            11
-- CREATE INDEX                             7
-- ALTER TABLE                             21
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0
