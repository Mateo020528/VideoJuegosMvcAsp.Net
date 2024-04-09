USE bgaeex5dedcb3sg4drc4;


CREATE TABLE VideoJuegos (
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Nombre VARCHAR(100) NOT NULL,
    Logo VARCHAR(255) NOT NULL,
    Descripcion TEXT NOT NULL,
    Cantidad INT NOT NULL,
    ConsolasCompatibles TEXT NOT NULL,
    JugableOnline TEXT NOT NULL,
    FechaDeLanzamiento DATE NOT NULL
);
SELECT * FROM VideoJuegos;

DROP TABLE VideoJuegos;
INSERT INTO VideoJuegos (id,Nombre,Logo,Descripcion,Cantidad,ConsolasCompatibles,JugableOnline,FechaDeLanzamiento) VALUES (1, "Final Fantasy","https://cdn.vox-cdn.com/thumbor/9eUdMkl-i0seN4eBv4ahbeE9TtQ=/0x0:1920x1080/1200x800/filters:focal(807x387:1113x693)/cdn.vox-cdn.com/uploads/chorus_image/image/60956053/Sekiro_24.0.jpg","Juego de luchas jugador contra jugador",25,"Nintendo,Xbox One,360, Play 3,4,5","Se puede jugar Online","2022-09-12");
