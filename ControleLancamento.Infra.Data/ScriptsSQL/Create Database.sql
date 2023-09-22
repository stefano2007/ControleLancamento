Create database dbControleLancamento;
go
Use dbControleLancamento;
GO

Create Table tbCategory(
  Id int not null identity(1, 1) primary key,
  nmCategory   varchar(100) not null,
  Color        varchar(7),
  Icon         varchar(20),
  ckActive     bit not null default 0,
  dtCreate     Datetime  not null default getdate()
)