Merhaba,



Sizlere Asp Net Core Api teknolojisi ile geliştirmiş olduğum ödeme merkezi projesini tanıtmak isterim.

Bu proje içerisinde herhangi bir önyüz geliştirmesi yapılmamış olup bir Rest API servisi olarak

hizmet vermektedir.Proje, içerisinde gişe görevlisi ve abone olarak iki ana gruba ayrılmış durumdadır.

Gişe görevlisi olarak yeni bir abonelik oluşturma işlemleri, abone sorgulama işlemleri,

fatura ödeme işlemleri ve abonelik kapatma işlemleri yapılırken, abone tarafında ise ise ödenmiş ve 

ödenmemiş faturaların listenme işlemleri yapılmaktadır. 

Fatura ekleme işlemi için herhangi bir servis mevcut değildir,bunlar manuel olarak DB'ye eklenmektedir.

Ayrıca proje içinde bazı algoritmalardan da bahsetmek isterim.

Yeni bir abone oluşturuken aboneliğe ait sabit depozito tutarı eklenerek abonelik 

kapatma işlemi yapılırken aboneye depozite tutarı iade edilmektedir ve abonelik kapatma işlemi 

yapılırken eğer ödenmemiş herhangi bir fatura varsa abonelik kapatma işleminin yapılması engellenmiş

durumdadır.

