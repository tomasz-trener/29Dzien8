
select * from zawodnicy

select * from trenerzy

select * from skocznie

select distinct kraj from zawodnicy


select id_zawodnika, id_trenera, imie, nazwisko, kraj, data_ur, wzrost,waga 
from zawodnicy
where kraj = 'pol'

select avg(wzrost)
from zawodnicy
where kraj = 'pol'




select * from zawodnicy

delete zawodnicy where id_zawodnika =1


insert into zawodnicy (id_zawodnika,id_trenera, imie, nazwisko, kraj, data_ur,wzrost,waga) values (18,1,'jan','kowalski','pol','20241114',10,23) 

delete zawodnicy where id_zawodnika is null

update zawodnicy set 
	id_trenera = 2,
	imie = 'adam',
	nazwisko = 'kowalski',
	kraj = 'usa',
	data_ur = '20230101',
	wzrost = 1,
	waga =2
	where id_zawodnika = 1

ALTER TABLE zawodnicy
alter column Id_zawodnika int not null

	ALTER TABLE zawodnicy
ADD CONSTRAINT PK_Zawodnicy_Id_zawodnika PRIMARY KEY (Id_zawodnika);

--ALTER TABLE zawodnicy
--alter column Id_zawodnika INT not null IDENTITY(1,1)
update zawodnicy set 
	                        id_trenera = 1,
	                        imie = 'Martin3',
	                        nazwisko = 'HOELLWARTH',
	                        kraj = 'AUT',
	                        data_ur = '19740413',
	                        wzrost = 182,
	                        waga =67
	                        where id_zawodnika = 11


-- chcemy policzyc sredni wiek zawodnikow z danego kraju 

select* from zawodnicy where kraj = 'ger'

select avg(DATEDIFF(year, data_ur, getdate())) as sredniWiek
from zawodnicy
where kraj = 'ger'


go
create procedure SredniWiekZawodnikow
	@kraj varchar(255),
	@sredniWiek int output 
as
begin
	select @sredniWiek= avg(DATEDIFF(year, data_ur, getdate())) 
	from zawodnicy
	where kraj = @kraj 
end

go


declare @sredniWiek int;
declare @kraj varchar(3) = 'GER';


exec SredniWiekZawodnikow @kraj,@sredniWiek output 

select @sredniWiek as SredniWiekZawodnikow

delete zawodnicy where kraj is null

insert into zawodnicy (id_trenera, imie, nazwisko, kraj, data_ur,wzrost,waga) values (null,'adam','nowak','POL','20241114',40,5)
                                                                                POL','20240101',1,1); drop table zawodnicy --