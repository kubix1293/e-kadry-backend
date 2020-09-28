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



-------------------------------------------------------------------------------------------------------------------