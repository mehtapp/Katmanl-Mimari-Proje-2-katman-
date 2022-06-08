create proc calisanListele
as begin 
Select * from calisan
end


create proc calisanEkle
@adSoyad varchar(50),
@yas int,
@adres varchar(50),
@mail varchar(50),
@maas int,
@pozisyonId int
as begin
insert into [dbo].[calisan] (cAdSoyad, cYas, cAdres, cMail, cMaas, pozisyonId) values (@adSoyad, @yas, @adres, @mail, @maas, @pozisyonId)
end



create proc calisanGüncelle
@id int,
@adSoyad varchar(50),
@yas int,
@adres varchar(50),
@mail varchar(50),
@maas int,
@pozisyonId int
as begin
update [dbo].[calisan] set cAdSoyad=@adSoyad, cYas=@yas, cAdres=@adres, cMail=@mail, cMaas= @maas, pozisyonId=@pozisyonId where calisanid=@id
end


create proc calisanSil
@id int
as begin 
delete from [dbo].[calisan] where calisanid=@id
end

create proc pozisyonListele
as begin
Select * from pozisyon
end

create proc pozisyonEkle
@pozisyonAdi varchar(50)
as begin
insert into [dbo].[pozisyon](pozizsyonAd) values (@pozisyonAdi)
end

create proc pozisyonGuncelle
@id int,
@pozisyonAdi varchar(50)
as begin
update [dbo].[pozisyon] set pozizsyonAd=@pozisyonAdi where pozisyonId=@id
end

create proc pozisyonSil
@id int 
as begin
delete from [dbo].[pozisyon] where pozisyonId=@id
end



create proc bolumListele
as begin
Select * from bolum
end

create proc bolumEkle
@bolumAdi varchar(50)
as begin
insert into [dbo].[bolum](bolumAd) values (@bolumAdi)
end

create proc bolumGuncelle
@id int,
@bolumAdi varchar(50)
as begin
update [dbo].[bolum] set bolumAd=@bolumAdi where id=@id
end

create proc bolumSil
@id int 
as begin
delete from [dbo].[bolum] where id=@id
end



create proc sirketListele
as begin
Select * from [dbo].[sirket]
end

create proc sirketEkle
@sAd varchar(50),
@sAdres varchar(50),
@sTel varchar(50),
@sMail varchar(50),
@bolumId int,
@pozId int
as begin
insert into [dbo].[sirket] (sAd, sAdres, sTel, sMail, bolumId, pozisyonId) values (@sAd, @sAdres, @sTel, @sMail, @bolumId, @pozId)
end

create proc sirketGuncelle
@sirketId int,
@sAd varchar(50),
@sAdres varchar(50),
@sTel varchar(50),
@sMail varchar(50),
@bolumId int,
@pozId int
as begin
update [dbo].[sirket] set sAd=@sAd, sAdres=@sAdres, sTel=@sTel, sMail= @sMail, bolumId=@bolumId, pozisyonId=@pozId where id=@sirketId
end

create proc sirketSil
@id int 
as begin
delete from [dbo].[sirket] where id=@id
end

