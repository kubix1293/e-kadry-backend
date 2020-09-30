------------------------------------------------------------------- Tworzenie schematu i nadawanie uprawnień
CONNECT system/manager AS sysdba

alter session set "_ORACLE_SCRIPT"=true;

CREATE USER kadry IDENTIFIED BY kadry;

GRANT CREATE SESSION TO kadry;

GRANT ALL PRIVILEGES TO kadry;

------------------------------------------------------------------- TABELS

------ ABSENCJE

CREATE SEQUENCE absencje_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.absencje (
    id          INTEGER DEFAULT absencje_seq.NEXTVAL NOT NULL,
    dtod        DATE NOT NULL,
    dtdo        DATE NOT NULL,
    id_typobec  INTEGER NOT NULL,
    id_prc      INTEGER NOT NULL,
    id_ump      INTEGER NOT NULL,
    zada        CHAR(1) DEFAULT  'N' NOT NULL
);
	
COMMENT ON COLUMN kadry.absencje.dtod IS
    'data od';

COMMENT ON COLUMN kadry.absencje.dtdo IS
    'data do';

COMMENT ON COLUMN kadry.absencje.id_typobec IS
    'typ obecności absencja';

COMMENT ON COLUMN kadry.absencje.id_prc IS
    'id pracownika';

COMMENT ON COLUMN kadry.absencje.id_ump IS
    'id umowy';

COMMENT ON COLUMN kadry.absencje.zada IS
    'czy urlop na żądanie. aktywuje  się tylko gdy urlop wypoczynkowy. domyślne N';

ALTER TABLE kadry.absencje ADD CONSTRAINT absencje_pk PRIMARY KEY ( id );

------  ADRESY

CREATE SEQUENCE adresy_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.adresy (
    id                  INTEGER DEFAULT adresy_seq.NEXTVAL NOT NULL,
    misc	            VARCHAR2(50) NOT NULL,
    gmina               VARCHAR2(50) NOT NULL,
    powiat              VARCHAR2(50) NOT NULL,
    wojew	            VARCHAR2(50) NOT NULL,
    teryt               NUMBER(8) NOT NULL,
	kod_pocz 			VARCHAR2(6) NOT NULL
);

ALTER TABLE kadry.adresy ADD CONSTRAINT adresy_pk PRIMARY KEY ( id );

ALTER TABLE kadry.adresy ADD CONSTRAINT adresy_teryt_un UNIQUE ( teryt );

------ HPS (HISTORIA POPRZEDNICH ZATRUDNIEŃ)

CREATE SEQUENCE hps_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.hps (
    id      INTEGER DEFAULT hps_seq.NEXTVAL NOT NULL,
    dtod    DATE NOT NULL,
    dtdo    DATE,
    stog    CHAR(1) DEFAULT 'N' NOT NULL,
    stzw    CHAR(1) DEFAULT 'N' NOT NULL,
    stws    CHAR(1) DEFAULT 'N' NOT NULL,
    stjb    CHAR(1) DEFAULT 'N' NOT NULL,
    id_prc  INTEGER NOT NULL
);

COMMENT ON COLUMN kadry.hps.stog IS
    'staż ogółem';

COMMENT ON COLUMN kadry.hps.stzw IS
    'staż w zawodzie';

COMMENT ON COLUMN kadry.hps.stws IS
    'staż do wysługi';

COMMENT ON COLUMN kadry.hps.stjb IS
    'staż do jubileuszu';

COMMENT ON COLUMN kadry.hps.id_prc IS
    'id pracownika';

ALTER TABLE kadry.hps ADD CONSTRAINT hps_pk PRIMARY KEY ( id );

------ OKRESY

CREATE SEQUENCE okresy_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.okresy (
    id       INTEGER DEFAULT okresy_seq.NEXTVAL NOT NULL,
    dtod     DATE NOT NULL,
    dtdo     DATE NOT NULL,
    dni_kal  NUMBER(4) NOT NULL,
    dni_rob  NUMBER(4)NOT NULL,
    norma    FLOAT(15) NOT NULL
);

COMMENT ON COLUMN kadry.okresy.dtod IS
    'pierwszy dzień miesiąca';

COMMENT ON COLUMN kadry.okresy.dtdo IS
    'ostatni dzień miesiąca';

COMMENT ON COLUMN kadry.okresy.dni_kal IS
    'dni kalendarzowe';

COMMENT ON COLUMN kadry.okresy.dni_rob IS
    'dni robocze';

COMMENT ON COLUMN kadry.okresy.norma IS
    'normatywny czas pracy';

ALTER TABLE kadry.okresy ADD CONSTRAINT okresy_pk PRIMARY KEY ( id );

------  PKZP

CREATE SEQUENCE pkzp_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.pkzp (
    id      INTEGER DEFAULT pkzp_seq.NEXTVAL NOT NULL,
    id_prc  INTEGER NOT NULL,
    saldo   FLOAT(15) DEFAULT 0,
    dt      FLOAT(15) DEFAULT 0,
    ct      FLOAT(15) DEFAULT 0,
    rodz    CHAR(1) NOT NULL
);

COMMENT ON COLUMN kadry.pkzp.id_prc IS
    'Id pracownika';

COMMENT ON COLUMN kadry.pkzp.saldo IS
    'Saldo PKZP danego rodzaju';

COMMENT ON COLUMN kadry.pkzp.dt IS
    'Debit - na "-"';

COMMENT ON COLUMN kadry.pkzp.ct IS
    'Credit - na "+"';

COMMENT ON COLUMN kadry.pkzp.rodz IS
    'Rodzaj PKZP
W - wkłady	
P - pożyczka';

ALTER TABLE kadry.pkzp ADD CONSTRAINT pkzp_pk PRIMARY KEY ( id );

------  PKZP_POZ

CREATE SEQUENCE pkzp_poz_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.pkzp_poz (
    id       INTEGER DEFAULT pkzp_poz_seq.NEXTVAL NOT NULL,
    rodz     CHAR(1) NOT NULL,
    kwot     FLOAT(15) DEFAULT 0 NOT NULL,
    id_pkzp  INTEGER NOT NULL
);

COMMENT ON COLUMN kadry.pkzp_poz.rodz IS
    'Rodzaj PKZP
W - wkład
P - pożyczka';

COMMENT ON COLUMN kadry.pkzp_poz.kwot IS
    'Kwota spłaty lub wkładu';

ALTER TABLE kadry.pkzp_poz ADD CONSTRAINT pkzp_poz_pk PRIMARY KEY ( id );

------ PRACOWNICY

CREATE SEQUENCE pracownicy_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.pracownicy (
    id        INTEGER DEFAULT pracownicy_seq.NEXTVAL NOT NULL,
    imie      VARCHAR2(20) NOT NULL,
    nazwisko  VARCHAR2(40) NOT NULL,
	dtur	  DATE,
	misc_uro  VARCHAR2(50),
    pesel     VARCHAR2(11) NOT NULL,
    dok_typ   CHAR(5),
    nr_dok    VARCHAR(20),
	plec	  CHAR(1),
    id_misc   INTEGER,
    ulica     VARCHAR2(50),
    nr_dom    VARCHAR2(10),
    nr_lok    VARCHAR2(10),
	nr_akt	  VARCHAR2(10),
	imie_mat  VARCHAR2(20),
	imie_ojc  VARCHAR2(40),
	tele	  VARCHAR2(15),
	id_oper	  INTEGER
);

COMMENT ON COLUMN kadry.pracownicy.dok_typ IS
    'Rodzaj dokumentu (dowod d, paszport p, karta_pobytu k)';

ALTER TABLE kadry.pracownicy ADD CONSTRAINT pracownicy_pk PRIMARY KEY ( id );

ALTER TABLE kadry.pracownicy ADD CONSTRAINT pracownicy_pesel_un UNIQUE ( pesel );

------ STANOW (STANOWISKA)

CREATE SEQUENCE stanow_seq INCREMENT BY 1 NOCACHE;
--
CREATE TABLE kadry.stanow (
    id       INTEGER DEFAULT stanow_seq.NEXTVAL NOT NULL,
    nazwa    VARCHAR2(50),
    kod_gus  NUMBER(10)
);
--
ALTER TABLE kadry.stanow ADD CONSTRAINT stanow_pk PRIMARY KEY ( id );

------ STAZTAB (TABELA STAŻÓW)

CREATE SEQUENCE staztab_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.staztab (
    id       INTEGER DEFAULT staztab_seq.NEXTVAL NOT NULL,
    stog     FLOAT(15) DEFAULT  0 NOT NULL,
    stwz     FLOAT(15) DEFAULT  0 NOT NULL,
    stws     FLOAT(15) DEFAULT  0 NOT NULL,
    stjb     FLOAT(15) DEFAULT  0 NOT NULL,
    id_prc   INTEGER NOT NULL,
    id_oks   INTEGER NOT NULL,
    url_prz  FLOAT(4) DEFAULT  0 NOT NULL,
    url_wyk  FLOAT(4) DEFAULT  0 NOT NULL,
    url_zal  FLOAT(4) DEFAULT  0 NOT NULL,
    url_sum  FLOAT(4) DEFAULT  0 NOT NULL
);

COMMENT ON COLUMN kadry.staztab.stog IS
    'staż ogółem - suma';
--
COMMENT ON COLUMN kadry.staztab.stwz IS
    'staż w zawodzie - suma';
--
COMMENT ON COLUMN kadry.staztab.stws IS
    'staż do wysługi - suma';
--
COMMENT ON COLUMN kadry.staztab.stjb IS
    'staż do jubileuszu - suma';
--
COMMENT ON COLUMN kadry.staztab.id_prc IS
    'id pracownika';
--
COMMENT ON COLUMN kadry.staztab.url_prz IS
    'urlop przysługujący';

ALTER TABLE kadry.staztab ADD CONSTRAINT staztab_pk PRIMARY KEY ( id );

------ UMOWY

CREATE SEQUENCE umowy_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.umowy (
    id             INTEGER DEFAULT umowy_seq.NEXTVAL NOT NULL,
    dtzaw          DATE NOT NULL,
    dtroz          DATE,
    zasad          FLOAT(15) DEFAULT 0 NOT NULL,
    id_stanow      INTEGER NOT NULL,
    id_typum       INTEGER NOT NULL,
    id_prc         INTEGER NOT NULL,
    nr_tyt_zus     NUMBER(5),
    czy_chor       CHAR(1) DEFAULT 'N' NOT NULL,
    czy_ren        CHAR(1) DEFAULT 'N' NOT NULL,
    czy_emer       CHAR(1) DEFAULT 'N' NOT NULL,
    czy_zdrow      CHAR(1) DEFAULT 'N' NOT NULL,
    czy_fp         CHAR(1) DEFAULT 'N' NOT NULL,
    czy_fgsp       CHAR(1) DEFAULT 'N' NOT NULL,
    czy_urlop      CHAR(1) DEFAULT 'N' NOT NULL,
    czy_ab_chor    CHAR(1) DEFAULT 'N' NOT NULL,
    nrm_czas_prac  FLOAT(15),
    stog           CHAR(1) DEFAULT 'N' NOT NULL,
    stzw           CHAR(1) DEFAULT 'N' NOT NULL,
    stws           CHAR(1) DEFAULT 'N' NOT NULL,
    stjb           CHAR(1) DEFAULT 'N' NOT NULL
);

COMMENT ON COLUMN kadry.umowy.nrm_czas_prac IS
    'Czas wprowadzany w postaci dziesiętnej. Aplikacja wywoła funckje, która po wpisaniu np.: 8:35 zmienia na liczbę naturalną z ułamkiem dziesiętnym. 
Zrobić funkcję, która przelicza liczbę dziesiętną na godzinę i funkcję odwrotną.';

COMMENT ON COLUMN kadry.umowy.stog IS
    'staż ogółem';

COMMENT ON COLUMN kadry.umowy.stzw IS
    'staż w zawodzie';

COMMENT ON COLUMN kadry.umowy.stws IS
    'staż do wysługi';

COMMENT ON COLUMN kadry.umowy.stjb IS
    'staż do jubileuszu';

ALTER TABLE kadry.umowy ADD CONSTRAINT umowy_pk PRIMARY KEY ( id );

------ TYPUM

CREATE SEQUENCE typum_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.typum (
    id             INTEGER DEFAULT typum_seq.NEXTVAL NOT NULL,
    nazwa          VARCHAR2(50),
    nr_tyt_zus     NUMBER(5),
    czy_chor       CHAR(1) DEFAULT 'N' NOT NULL,
    czy_ren        CHAR(1) DEFAULT 'N' NOT NULL,
    czy_emer       CHAR(1) DEFAULT 'N' NOT NULL,
    czy_zdrow      CHAR(1) DEFAULT 'N' NOT NULL,
    czy_fp         CHAR(1) DEFAULT 'N' NOT NULL,
    czy_fgsp       CHAR(1) DEFAULT 'N' NOT NULL,
    czy_urlop      CHAR(1) DEFAULT 'N' NOT NULL,
    czy_ab_chor    CHAR(1) DEFAULT 'N' NOT NULL,
    nrm_czas_prac  FLOAT(15),
    stog           CHAR(1) DEFAULT 'N' NOT NULL,
    stzw           CHAR(1) DEFAULT 'N' NOT NULL,
    stws           CHAR(1) DEFAULT 'N' NOT NULL,
    stjb           CHAR(1) DEFAULT 'N' NOT NULL,
    rodz_um        NUMBER(1)
);

ALTER TABLE kadry.typum ADD CONSTRAINT typum_pk PRIMARY KEY ( id );

------ TYPOBEC

CREATE SEQUENCE typobec_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.typobec (
    id             INTEGER DEFAULT typobec_seq.NEXTVAL NOT NULL,
    nazwa          VARCHAR2(50),
    cdot           VARCHAR2(5),
    kod_zus        VARCHAR2(3),
    czy_lim        CHAR(1),
    rodz_lim       CHAR(1),
    lim            NUMBER(10,4)
);

ALTER TABLE kadry.typobec ADD CONSTRAINT typobec_pk PRIMARY KEY ( id );

COMMENT ON COLUMN kadry.typobec.cdot IS
    'Czego dotyczy obecnosc (CHR - choroba, UWP - Urlop wypoczynkowy, GPR - godziny pracy itd.)';
    
COMMENT ON COLUMN kadry.typobec.kod_zus IS
    'KOD zwolnienia wedug ZUS (dla chorobowych)'; 
    
COMMENT ON COLUMN kadry.typobec.rodz_lim IS
    'Rodzaj imitu: r - roczny, i - indywidualny';    
	
COMMENT ON COLUMN kadry.typobec.lim IS
    'Ile dni limitu';   

------ OPER (OPERATOR)

CREATE SEQUENCE oper_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.oper ( 
	id			INTEGER DEFAULT oper_seq.NEXTVAL NOT NULL,
	imie		VARCHAR2(20) NOT NULL,
	nazwisko	VARCHAR2(35) NOT NULL,
	login		VARCHAR2(50) NOT NULL,
	passw		VARCHAR2(40) NOT NULL,
	aktw		CHAR(1) DEFAULT 'T' NOT NULL
	);
	
ALTER TABLE kadry.oper ADD CONSTRAINT oper_pk PRIMARY KEY (id);	

------ URZEDY (URZEDY)

CREATE SEQUENCE urzedy_seq INCREMENT BY 1 NOCACHE;

CREATE TABLE kadry.urzedy ( 
	id			INTEGER DEFAULT urzedy_seq.NEXTVAL NOT NULL,
	woje		VARCHAR2(20) NOT NULL,
	typ     	VARCHAR2(35) NOT NULL,
	kod 		VARCHAR2(70) NOT NULL,
	adres		VARCHAR2(70) NOT NULL,
	kodisus		VARCHAR2(40) NOT NULL
	);
	
ALTER TABLE kadry.urzedy ADD CONSTRAINT urzedy_pk PRIMARY KEY (id);

-------------------------------------------------------------------------------------------------------------------




-------------------------------------------------------------------------------------------------------------------