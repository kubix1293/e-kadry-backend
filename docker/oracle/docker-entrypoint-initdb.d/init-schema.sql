------------------------------------------------------------------- Tworzenie schematu i nadawanie uprawnień

------------------------------------------------------------------- TABELS
/*
------ ABSENCJE
CREATE SEQUENCE absencje_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.absencje
(
    id         INTEGER   DEFAULT absencje_seq.NEXTVAL NOT NULL,
    dtod       DATE                                   NOT NULL,
    dtdo       DATE                                   NOT NULL,
    id_typobec INTEGER                                NOT NULL,
    id_prc     INTEGER                                NOT NULL,
    id_ump     INTEGER                                NOT NULL,
    zada       NUMBER(1) DEFAULT 0                    NOT NULL
);
/
COMMENT ON COLUMN kadry.absencje.dtod IS
    'data od';
/
COMMENT ON COLUMN kadry.absencje.dtdo IS
    'data do';
/
COMMENT ON COLUMN kadry.absencje.id_typobec IS
    'typ obecności absencja';
/
COMMENT ON COLUMN kadry.absencje.id_prc IS
    'id pracownika';
/
COMMENT ON COLUMN kadry.absencje.id_ump IS
    'id umowy';
/
COMMENT ON COLUMN kadry.absencje.zada IS
    'czy urlop na żądanie. aktywuje  się tylko gdy urlop wypoczynkowy. domyślne N';
/
ALTER TABLE kadry.absencje
    ADD CONSTRAINT absencje_pk PRIMARY KEY (id);
/
*/
------  ADRESY
CREATE TABLE kadry.adresy
(
    id       RAW(32) DEFAULT SYS_GUID() NOT NULL,
    misc     VARCHAR2(50)               NOT NULL,
    gmina    VARCHAR2(50)               NOT NULL,
    powiat   VARCHAR2(50)               NOT NULL,
    wojew    VARCHAR2(50)               NOT NULL,
    teryt    NUMBER(8)                  NOT NULL,
    kod_pocz VARCHAR2(6)                NOT NULL
);
/
ALTER TABLE kadry.adresy
    ADD CONSTRAINT adresy_pk PRIMARY KEY (id);
/
ALTER TABLE kadry.adresy
    ADD CONSTRAINT adresy_teryt_un UNIQUE (teryt);
/
/*

------ HPS (HISTORIA POPRZEDNICH ZATRUDNIEŃ)
CREATE SEQUENCE hps_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.hps
(
    id     INTEGER   DEFAULT hps_seq.NEXTVAL NOT NULL,
    dtod   DATE                              NOT NULL,
    dtdo   DATE,
    stog   NUMBER(1) DEFAULT 0               NOT NULL,
    stzw   NUMBER(1) DEFAULT 0               NOT NULL,
    stws   NUMBER(1) DEFAULT 0               NOT NULL,
    stjb   NUMBER(1) DEFAULT 0               NOT NULL,
    id_prc INTEGER                           NOT NULL
);
/
COMMENT ON COLUMN kadry.hps.stog IS
    'staż ogółem';
/
COMMENT ON COLUMN kadry.hps.stzw IS
    'staż w zawodzie';
/
COMMENT ON COLUMN kadry.hps.stws IS
    'staż do wysługi';
/
COMMENT ON COLUMN kadry.hps.stjb IS
    'staż do jubileuszu';
/
COMMENT ON COLUMN kadry.hps.id_prc IS
    'id pracownika';
/
ALTER TABLE kadry.hps
    ADD CONSTRAINT hps_pk PRIMARY KEY (id);
/
*/

------ OKRESY
CREATE TABLE kadry.okresy
(
    id      RAW(32) DEFAULT SYS_GUID() NOT NULL,
    dtod    DATE                       NOT NULL,
    dtdo    DATE                       NOT NULL,
    dni_kal NUMBER(4)                  NOT NULL,
    dni_rob NUMBER(4)                  NOT NULL,
    norma   FLOAT(15)                  NOT NULL
);
/
COMMENT ON COLUMN kadry.okresy.dtod IS
    'pierwszy dzień miesiąca';
/
COMMENT ON COLUMN kadry.okresy.dtdo IS
    'ostatni dzień miesiąca';
/
COMMENT ON COLUMN kadry.okresy.dni_kal IS
    'dni kalendarzowe';
/
COMMENT ON COLUMN kadry.okresy.dni_rob IS
    'dni robocze';
/
COMMENT ON COLUMN kadry.okresy.norma IS
    'normatywny czas pracy';
/
ALTER TABLE kadry.okresy
    ADD CONSTRAINT okresy_pk PRIMARY KEY (id);
/

------  PKZP
CREATE TABLE kadry.pkzp
(
    id     RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    id_prc RAW(32)                      NOT NULL,
    saldo  FLOAT(15) DEFAULT 0,
    dt     FLOAT(15) DEFAULT 0,
    ct     FLOAT(15) DEFAULT 0,
    rodz   NUMBER                       NOT NULL
);
/
COMMENT ON COLUMN kadry.pkzp.id_prc IS
    'Id pracownika';
/
COMMENT ON COLUMN kadry.pkzp.saldo IS
    'Saldo PKZP danego rodzaju';
/
COMMENT ON COLUMN kadry.pkzp.dt IS
    'Debit - na "-"';
/
COMMENT ON COLUMN kadry.pkzp.ct IS
    'Credit - na "+"';
/
COMMENT ON COLUMN kadry.pkzp.rodz IS
    'Rodzaj PKZP
1 - wkłady
10 - pożyczka';
/
ALTER TABLE kadry.pkzp
    ADD CONSTRAINT pkzp_pk PRIMARY KEY (id);
/

------  PKZP_POZ
CREATE TABLE kadry.pkzp_poz
(
    id      RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    rodz    NUMBER                       NOT NULL,
    kwot    FLOAT(15) DEFAULT 0          NOT NULL,
    id_pkzp RAW(32)                      NOT NULL
);
/
COMMENT ON COLUMN kadry.pkzp_poz.rodz IS
    'Rodzaj PKZP
1 - wkład
10 - pożyczka
20 - wpisowe'; 
/
COMMENT ON COLUMN kadry.pkzp_poz.kwot IS
    'Kwota spłaty lub wkładu ';
/
ALTER TABLE kadry.pkzp_poz
    ADD CONSTRAINT pkzp_poz_pk PRIMARY KEY (id);
/

------ PKZP_PARAM
CREATE TABLE kadry.pkzp_param
(
    forma   NUMBER(1) DEFAULT 0  NOT NULL,
    ile_rat NUMBER(2) DEFAULT 12 NOT NULL,
    wklad   FLOAT(10) DEFAULT 0  NOT NULL,
    sklad   FLOAT(10) DEFAULT 0  NOT NULL
);
/
COMMENT ON COLUMN kadry.pkzp_param.forma IS
    'Forma składek  0 - %,  1 - zł';
/
COMMENT ON COLUMN kadry.pkzp_param.wklad IS
    'wartość wkładu początkowego';
/
COMMENT ON COLUMN kadry.pkzp_param.sklad IS
    'wartość składki PKZP';
/

------ PRACOWNICY
CREATE TABLE kadry.pracownicy
(
    id             RAW(32) DEFAULT SYS_GUID()   NOT NULL,
    imie           VARCHAR2(20)                 NOT NULL,
    nazwisko       VARCHAR2(40)                 NOT NULL,
    dtur           DATE,
    misc_uro       VARCHAR2(50),
    pesel          VARCHAR2(11)                 NOT NULL,
    dok_typ        INTEGER,
    nr_dok         VARCHAR(20),
    plec           INTEGER,
    id_misc        RAW(32),
    ulica          VARCHAR2(50),
    nr_dom         VARCHAR2(10),
    nr_lok         VARCHAR2(10),
    nr_akt         VARCHAR2(10),
    imie_mat       VARCHAR2(20),
    imie_ojc       VARCHAR2(40),
    tele           VARCHAR2(15),
    id_oper        RAW(32),
    usuniety       DATE,
    utworzony      DATE    DEFAULT current_date NOT NULL,
    zaktualizowany DATE    DEFAULT current_date NOT NULL
);
/
ALTER TABLE kadry.pracownicy
    ADD CONSTRAINT pracownicy_pk PRIMARY KEY (id);
/
ALTER TABLE kadry.pracownicy
    ADD CONSTRAINT pracownicy_pesel_un UNIQUE (pesel);
/
------ STANOW (STANOWISKA)
CREATE TABLE kadry.stanow
(
    id      RAW(32) DEFAULT SYS_GUID() NOT NULL,
    nazwa   VARCHAR2(50),
    kod_gus NUMBER(10)
);
/
ALTER TABLE kadry.stanow
    ADD CONSTRAINT stanow_pk PRIMARY KEY (id);
/
------ STAZTAB (TABELA STAŻÓW)
CREATE TABLE kadry.staztab
(
    id      RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    stog    FLOAT(15) DEFAULT 0          NOT NULL,
    stwz    FLOAT(15) DEFAULT 0          NOT NULL,
    stws    FLOAT(15) DEFAULT 0          NOT NULL,
    stjb    FLOAT(15) DEFAULT 0          NOT NULL,
    id_prc  RAW(32)                      NOT NULL,
    id_oks  RAW(32)                      NOT NULL,
    url_prz FLOAT(4)  DEFAULT 0          NOT NULL,
    url_wyk FLOAT(4)  DEFAULT 0          NOT NULL,
    url_zal FLOAT(4)  DEFAULT 0          NOT NULL,
    url_sum FLOAT(4)  DEFAULT 0          NOT NULL
);
/
COMMENT ON COLUMN kadry.staztab.stog IS
    'staż ogółem - suma';
/
COMMENT ON COLUMN kadry.staztab.stwz IS
    'staż w zawodzie - suma';
/
COMMENT ON COLUMN kadry.staztab.stws IS
    'staż do wysługi - suma';
/
COMMENT ON COLUMN kadry.staztab.stjb IS
    'staż do jubileuszu - suma';
/
COMMENT ON COLUMN kadry.staztab.id_prc IS
    'id pracownika';
/
COMMENT ON COLUMN kadry.staztab.url_prz IS
    'urlop przysługujący';
/
ALTER TABLE kadry.staztab
    ADD CONSTRAINT staztab_pk PRIMARY KEY (id);
/
------ UMOWY
CREATE TABLE kadry.umowy
(
    id            RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    dtzaw         DATE                         NOT NULL,
    dtroz         DATE,
    zasad         FLOAT(15) DEFAULT 0          NOT NULL,
    id_stanow     RAW(32)                      NOT NULL,
    id_typum      RAW(32)                      NOT NULL,
    id_prc        RAW(32)                      NOT NULL,
    nr_tyt_zus    NUMBER(5),
    czy_chor      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ren       NUMBER(1) DEFAULT 0          NOT NULL,
    czy_emer      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_zdrow     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fp        NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fgsp      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_urlop     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ab_chor   NUMBER(1) DEFAULT 0          NOT NULL,
    nrm_czas_prac FLOAT(15),
    stog          NUMBER(1) DEFAULT 0          NOT NULL,
    stzw          NUMBER(1) DEFAULT 0          NOT NULL,
    stws          NUMBER(1) DEFAULT 0          NOT NULL,
    stjb          NUMBER(1) DEFAULT 0          NOT NULL
);
/
COMMENT ON COLUMN kadry.umowy.nrm_czas_prac IS
    'Czas wprowadzany w postaci dziesiętnej. Aplikacja wywoła funckje, która po wpisaniu np.: 8:35 zmienia na liczbę naturalną z ułamkiem dziesiętnym.
Zrobić funkcję, która przelicza liczbę dziesiętną na godzinę i funkcję odwrotną.';
/
COMMENT ON COLUMN kadry.umowy.stog IS
    'staż ogółem';
/
COMMENT ON COLUMN kadry.umowy.stzw IS
    'staż w zawodzie';
/
COMMENT ON COLUMN kadry.umowy.stws IS
    'staż do wysługi';
/
COMMENT ON COLUMN kadry.umowy.stjb IS
    'staż do jubileuszu';
/
ALTER TABLE kadry.umowy
    ADD CONSTRAINT umowy_pk PRIMARY KEY (id);
/
------ TYPUM
CREATE TABLE kadry.typum
(
    id            RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    nazwa         VARCHAR2(50),
    nr_tyt_zus    NUMBER(5),
    czy_chor      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ren       NUMBER(1) DEFAULT 0          NOT NULL,
    czy_emer      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_zdrow     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fp        NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fgsp      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_urlop     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ab_chor   NUMBER(1) DEFAULT 0          NOT NULL,
    nrm_czas_prac FLOAT(15),
    stog          NUMBER(1) DEFAULT 0          NOT NULL,
    stzw          NUMBER(1) DEFAULT 0          NOT NULL,
    stws          NUMBER(1) DEFAULT 0          NOT NULL,
    stjb          NUMBER(1) DEFAULT 0          NOT NULL,
    rodz_um       NUMBER
);
/
ALTER TABLE kadry.typum
    ADD CONSTRAINT typum_pk PRIMARY KEY (id);
/
COMMENT ON COLUMN kadry.typum.rodz_um IS
    'rodzaj umowy, 1 - umowa o prace, 10 - umowa zlec., 20 - umowa o dziel.';
/

/*
------ TYPOBEC
CREATE SEQUENCE typobec_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.typobec
(
    id       INTEGER DEFAULT typobec_seq.NEXTVAL NOT NULL,
    nazwa    VARCHAR2(50),
    cdot     VARCHAR2(5),
    kod_zus  VARCHAR2(3),
    czy_lim  NUMBER(1),
    rodz_lim CHAR(1),
    lim      NUMBER(10, 4)
);
/
ALTER TABLE kadry.typobec
    ADD CONSTRAINT typobec_pk PRIMARY KEY (id);
/
COMMENT ON COLUMN kadry.typobec.cdot IS
    'Czego dotyczy obecnosc (CHR - choroba, UWP - Urlop wypoczynkowy, GPR - godziny pracy itd.)';
/
COMMENT ON COLUMN kadry.typobec.kod_zus IS
    'KOD zwolnienia wedug ZUS (dla chorobowych)';
/
COMMENT ON COLUMN kadry.typobec.CZY_lim IS
    'Czy obejmuje limit 0 - nie - 1 - tak';
/
COMMENT ON COLUMN kadry.typobec.rodz_lim IS
    'Rodzaj imitu: r - roczny, i - indywidualny';
/
COMMENT ON COLUMN kadry.typobec.lim IS
    'Ile dni limitu';
/
*/

------ OPER (OPERATOR)
CREATE SEQUENCE oper_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.oper
(
    id             RAW(32)   DEFAULT SYS_GUID()   NOT NULL,
    imie           VARCHAR2(20)                   NOT NULL,
    nazwisko       VARCHAR2(35)                   NOT NULL,
    login          VARCHAR2(50)                   NOT NULL,
    passw          VARCHAR2(40)                   NOT NULL,
    aktw           NUMBER(1) DEFAULT 1            NOT NULL,
    usuniety       DATE,
    utworzony      DATE      DEFAULT current_date NOT NULL,
    zaktualizowany DATE      DEFAULT current_date NOT NULL
);
/
ALTER TABLE kadry.oper
    ADD CONSTRAINT oper_pk PRIMARY KEY (id);
/

------ URZEDY (URZEDY)
CREATE SEQUENCE urzedy_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.urzedy
(
    id      RAW(32) DEFAULT SYS_GUID() NOT NULL,
    woje    VARCHAR2(20)               NOT NULL,
    typ     VARCHAR2(35)               NOT NULL,
    kod     VARCHAR2(70)               NOT NULL,
    adres   VARCHAR2(70)               NOT NULL,
    kodisus VARCHAR2(40)               NOT NULL
);
/
ALTER TABLE kadry.urzedy
    ADD CONSTRAINT urzedy_pk PRIMARY KEY (id);

-------------------------------------------------------------------  CIENIE
------ PRACONICY_C
CREATE SEQUENCE pracownicy_c_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.pracownicy_c
(
    c_id     RAW(32) DEFAULT SYS_GUID() NOT NULL,
    c_data   DATE    DEFAULT sysdate    NOT NULL,
    c_oper   RAW(32)                    NOT NULL,
    id       RAW(32)                    NOT NULL,
    imie     VARCHAR2(20)               NOT NULL,
    nazwisko VARCHAR2(40)               NOT NULL,
    dtur     DATE,
    misc_uro VARCHAR2(50),
    pesel    VARCHAR2(11)               NOT NULL,
    dok_typ  NUMBER,
    nr_dok   VARCHAR(20),
    plec     NUMBER,
    id_misc  RAW(32),
    ulica    VARCHAR2(50),
    nr_dom   VARCHAR2(10),
    nr_lok   VARCHAR2(10),
    nr_akt   VARCHAR2(10),
    imie_mat VARCHAR2(20),
    imie_ojc VARCHAR2(40),
    tele     VARCHAR2(15),
    id_oper  RAW(32)
);
/
ALTER TABLE kadry.pracownicy_c
    ADD CONSTRAINT pracownicy_c_pk PRIMARY KEY (c_id);
/

/*
------ ABSENCJE_C
CREATE SEQUENCE absencje_c_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.absencje_c
(
    c_id       INTEGER DEFAULT absencje_c_seq.NEXTVAL NOT NULL,
    c_data     DATE    DEFAULT sysdate                NOT NULL,
    c_oper     INTEGER                                NOT NULL,
    id         INTEGER                                NOT NULL,
    dtod       DATE                                   NOT NULL,
    dtdo       DATE                                   NOT NULL,
    id_typobec INTEGER                                NOT NULL,
    id_prc     INTEGER                                NOT NULL,
    id_ump     INTEGER                                NOT NULL,
    zada       CHAR(1) DEFAULT 'N'                    NOT NULL
);
/
ALTER TABLE kadry.absencje_c
    ADD CONSTRAINT absencje_c_pk PRIMARY KEY (c_id);
/
*/

------  ADRESY_C
CREATE TABLE kadry.adresy_c
(
    c_id     RAW(32) DEFAULT SYS_GUID() NOT NULL,
    c_data   DATE                       NOT NULL,
    c_oper   RAW(32)                    NOT NULL,
    id       RAW(32)                    NOT NULL,
    misc     VARCHAR2(50)               NOT NULL,
    gmina    VARCHAR2(50)               NOT NULL,
    powiat   VARCHAR2(50)               NOT NULL,
    wojew    VARCHAR2(50)               NOT NULL,
    teryt    NUMBER(8)                  NOT NULL,
    kod_pocz VARCHAR2(6)                NOT NULL
);
/
ALTER TABLE kadry.adresy_c
    ADD CONSTRAINT adresy_c_pk PRIMARY KEY (c_id);
/

/*
------ HPS_C (HISTORIA POPRZEDNICH ZATRUDNIEN)
CREATE SEQUENCE hps_c_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.hps_c
(
    c_id   INTEGER   DEFAULT hps_c_seq.NEXTVAL NOT NULL,
    c_data DATE                                NOT NULL,
    c_oper INTEGER                             NOT NULL,
    id     INTEGER                             NOT NULL,
    dtod   DATE                                NOT NULL,
    dtdo   DATE,
    stog   NUMBER(1) DEFAULT 0                 NOT NULL,
    stzw   NUMBER(1) DEFAULT 0                 NOT NULL,
    stws   NUMBER(1) DEFAULT 0                 NOT NULL,
    stjb   NUMBER(1) DEFAULT 0                 NOT NULL,
    id_prc INTEGER                             NOT NULL
);
/
ALTER TABLE kadry.hps_c
    ADD CONSTRAINT hps_c_pk PRIMARY KEY (c_id);
/
*/

------ OKRESY_C
CREATE TABLE kadry.okresy_c
(
    c_id    RAW(32) DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE                       NOT NULL,
    c_oper  RAW(32)                    NOT NULL,
    id      RAW(32)                    NOT NULL,
    dtod    DATE                       NOT NULL,
    dtdo    DATE                       NOT NULL,
    dni_kal NUMBER(4)                  NOT NULL,
    dni_rob NUMBER(4)                  NOT NULL,
    norma   FLOAT(15)                  NOT NULL
);
/
ALTER TABLE kadry.okresy_c
    ADD CONSTRAINT okresy_c_pk PRIMARY KEY (c_id);
/

------ OPER_C
CREATE TABLE kadry.oper_c
(
    c_id           RAW(32)   DEFAULT SYS_GUID()   NOT NULL,
    c_data         DATE      DEFAULT sysdate      NOT NULL,
    c_oper         RAW(32)                        NOT NULL,
    id             RAW(32)                        NOT NULL,
    imie           VARCHAR2(20)                   NOT NULL,
    nazwisko       VARCHAR2(35)                   NOT NULL,
    login          VARCHAR2(50)                   NOT NULL,
    passw          VARCHAR2(40)                   NOT NULL,
    aktw           NUMBER(1) DEFAULT 1            NOT NULL,
    usuniety       DATE,
    utworzony      DATE      DEFAULT current_date NOT NULL,
    zaktualizowany DATE      DEFAULT current_date NOT NULL
);
/
ALTER TABLE kadry.oper_c
    ADD CONSTRAINT oper_c_pk PRIMARY KEY (c_id);
/

------  PKZP_C
CREATE TABLE kadry.pkzp_c
(
    c_id   RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data DATE                         NOT NULL,
    c_oper RAW(32)                      NOT NULL,
    id     RAW(32)                      NOT NULL,
    id_prc RAW(32)                      NOT NULL,
    saldo  FLOAT(15) DEFAULT 0,
    dt     FLOAT(15) DEFAULT 0,
    ct     FLOAT(15) DEFAULT 0,
    rodz   NUMBER                       NOT NULL
);
/
ALTER TABLE kadry.pkzp_c
    ADD CONSTRAINT pkzp_c_pk PRIMARY KEY (c_id);
/

------  PKZP_POZ_C
CREATE TABLE kadry.pkzp_poz_c
(
    c_id    RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE      DEFAULT sysdate    NOT NULL,
    c_oper  RAW(32)                      NOT NULL,
    id      RAW(32)                      NOT NULL,
    rodz    CHAR(1)                      NOT NULL,
    kwot    FLOAT(15) DEFAULT 0          NOT NULL,
    id_pkzp RAW(32)                      NOT NULL
);
/
ALTER TABLE kadry.pkzp_poz_c
    ADD CONSTRAINT pkzp_poz_c_pk PRIMARY KEY (c_id);
/
------ STANOW_C (STANOWISKA)
CREATE TABLE kadry.stanow_c
(
    c_id    RAW(32) DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE    DEFAULT sysdate    NOT NULL,
    c_oper  RAW(32)                    NOT NULL,
    id      RAW(32)                    NOT NULL,
    nazwa   VARCHAR2(50),
    kod_gus NUMBER(10)
);
/
ALTER TABLE kadry.stanow_c
    ADD CONSTRAINT stanow_c_pk PRIMARY KEY (id);
/

------ STAZTAB_C (TABELA STAZOW)
CREATE TABLE kadry.staztab_c
(
    c_id    RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE      DEFAULT sysdate    NOT NULL,
    c_oper  RAW(32)                      NOT NULL,
    id      RAW(32)                      NOT NULL,
    stog    FLOAT(15) DEFAULT 0          NOT NULL,
    stwz    FLOAT(15) DEFAULT 0          NOT NULL,
    stws    FLOAT(15) DEFAULT 0          NOT NULL,
    stjb    FLOAT(15) DEFAULT 0          NOT NULL,
    id_prc  RAW(32)                      NOT NULL,
    id_oks  RAW(32)                      NOT NULL,
    url_prz FLOAT(4)  DEFAULT 0          NOT NULL,
    url_wyk FLOAT(4)  DEFAULT 0          NOT NULL,
    url_zal FLOAT(4)  DEFAULT 0          NOT NULL,
    url_sum FLOAT(4)  DEFAULT 0          NOT NULL
);
/
ALTER TABLE kadry.staztab_c
    ADD CONSTRAINT staztab_c_pk PRIMARY KEY (c_id);
/
------ UMOWY_C
CREATE TABLE kadry.umowy_c
(
    c_id          RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data        DATE      DEFAULT sysdate    NOT NULL,
    c_oper        RAW(32)                      NOT NULL,
    id            RAW(32)                      NOT NULL,
    dtzaw         DATE                         NOT NULL,
    dtroz         DATE,
    zasad         FLOAT(15) DEFAULT 0          NOT NULL,
    id_stanow     RAW(32)                      NOT NULL,
    id_typum      RAW(32)                      NOT NULL,
    id_prc        RAW(32)                      NOT NULL,
    nr_tyt_zus    NUMBER(5),
    czy_chor      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ren       NUMBER(1) DEFAULT 0          NOT NULL,
    czy_emer      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_zdrow     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fp        NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fgsp      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_urlop     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ab_chor   NUMBER(1) DEFAULT 0          NOT NULL,
    nrm_czas_prac FLOAT(15),
    stog          NUMBER(1) DEFAULT 0          NOT NULL,
    stzw          NUMBER(1) DEFAULT 0          NOT NULL,
    stws          NUMBER(1) DEFAULT 0          NOT NULL,
    stjb          NUMBER(1) DEFAULT 0          NOT NULL
);
/
ALTER TABLE kadry.umowy_c
    ADD CONSTRAINT umowy_c_pk PRIMARY KEY (c_id);
/

------ TYPUM_C
CREATE TABLE kadry.typum_c
(
    c_id          RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data        DATE      DEFAULT sysdate    NOT NULL,
    c_oper        RAW(32)                      NOT NULL,
    id            RAW(32)                      NOT NULL,
    nazwa         VARCHAR2(50),
    nr_tyt_zus    NUMBER(5),
    czy_chor      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ren       NUMBER(1) DEFAULT 0          NOT NULL,
    czy_emer      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_zdrow     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fp        NUMBER(1) DEFAULT 0          NOT NULL,
    czy_fgsp      NUMBER(1) DEFAULT 0          NOT NULL,
    czy_urlop     NUMBER(1) DEFAULT 0          NOT NULL,
    czy_ab_chor   NUMBER(1) DEFAULT 0          NOT NULL,
    nrm_czas_prac FLOAT(15),
    stog          NUMBER(1) DEFAULT 0          NOT NULL,
    stzw          NUMBER(1) DEFAULT 0          NOT NULL,
    stws          NUMBER(1) DEFAULT 0          NOT NULL,
    stjb          NUMBER(1) DEFAULT 0          NOT NULL,
    rodz_um       NUMBER
);
/
ALTER TABLE kadry.typum_c
    ADD CONSTRAINT typum_c_pk PRIMARY KEY (c_id);
/

/*
------ TYPOBEC_C
CREATE SEQUENCE typobec_c_seq INCREMENT BY 1 NOCACHE;
/
CREATE TABLE kadry.typobec_c
(
    c_id     INTEGER DEFAULT typobec_c_seq.NEXTVAL NOT NULL,
    c_data   DATE    DEFAULT sysdate               NOT NULL,
    c_oper   INTEGER                               NOT NULL,
    id       INTEGER                               NOT NULL,
    nazwa    VARCHAR2(50),
    cdot     VARCHAR2(5),
    kod_zus  VARCHAR2(3),
    czy_lim  NUMBER(1),
    rodz_lim CHAR(1),
    lim      NUMBER(10, 4)
);
/
ALTER TABLE kadry.typobec_c
    ADD CONSTRAINT typobec_c_pk PRIMARY KEY (id);
/
*/
-------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------  CONSTRAINTS
/*
ALTER TABLE kadry.absencje
    ADD CONSTRAINT absencje_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.absencje
    ADD CONSTRAINT absencje_umowy_fk FOREIGN KEY (id_ump)
        REFERENCES kadry.umowy (id);
/
ALTER TABLE kadry.absencje
    ADD CONSTRAINT absencje_typobec_fk FOREIGN KEY (id_typobec)
        REFERENCES kadry.typobec (id);
/
ALTER TABLE kadry.hps
    ADD CONSTRAINT hps_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
*/
ALTER TABLE kadry.pkzp
    ADD CONSTRAINT pkzp_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.pkzp_poz
    ADD CONSTRAINT pkzppoz_pkzp_fk FOREIGN KEY (id_pkzp)
        REFERENCES kadry.pkzp (id);
/
ALTER TABLE kadry.pracownicy
    ADD CONSTRAINT pracownicy_adresy_fk FOREIGN KEY (id_misc)
        REFERENCES kadry.adresy (id);
/
ALTER TABLE kadry.pracownicy
    ADD CONSTRAINT pracownicy_oper_fk FOREIGN KEY (id_oper)
        REFERENCES kadry.oper (id);
/
ALTER TABLE kadry.staztab
    ADD CONSTRAINT staztab_okresy_fk FOREIGN KEY (id_oks)
        REFERENCES kadry.okresy (id);
/
ALTER TABLE kadry.staztab
    ADD CONSTRAINT staztab_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.umowy
    ADD CONSTRAINT umowy_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.umowy
    ADD CONSTRAINT umowy_stanow_fk FOREIGN KEY (id_stanow)
        REFERENCES kadry.stanow (id);
/
ALTER TABLE kadry.umowy
    ADD CONSTRAINT umowy_typum_fk FOREIGN KEY (id_typum)
        REFERENCES kadry.typum (id);
/
ALTER TABLE kadry.pracownicy_c
    ADD CONSTRAINT pracownicy_c_prac_fk FOREIGN KEY (id)
        REFERENCES kadry.pracownicy (id);
/
/*
ALTER TABLE kadry.typobec_c
    ADD CONSTRAINT typobec_c_typobec_fk FOREIGN KEY (id)
        REFERENCES kadry.typobec (id);
/
ALTER TABLE kadry.absencje_c
    ADD CONSTRAINT absencje_c_absencje_fk FOREIGN KEY (id)
        REFERENCES kadry.absencje (id);
/
*/
ALTER TABLE kadry.adresy_c
    ADD CONSTRAINT adresy_c_adresy_fk FOREIGN KEY (id)
        REFERENCES kadry.adresy (id);
/
/*
ALTER TABLE kadry.hps_c
    ADD CONSTRAINT hps_c_hps_fk FOREIGN KEY (id)
        REFERENCES kadry.hps (id);
/
*/
ALTER TABLE kadry.okresy_c
    ADD CONSTRAINT okresy_c_okresy_fk FOREIGN KEY (id)
        REFERENCES kadry.okresy (id);
/
ALTER TABLE kadry.oper_c
    ADD CONSTRAINT oper_c_oper_fk FOREIGN KEY (id)
        REFERENCES kadry.oper (id);
/
ALTER TABLE kadry.pkzp_c
    ADD CONSTRAINT pkzp_c_pkzp_fk FOREIGN KEY (id)
        REFERENCES kadry.pkzp (id);
/
ALTER TABLE kadry.pkzp_poz_c
    ADD CONSTRAINT pkzp_poz_c_pkzp_poz_fk FOREIGN KEY (id)
        REFERENCES kadry.pkzp_poz (id);
/
ALTER TABLE kadry.stanow_c
    ADD CONSTRAINT stanow_c_stanow_fk FOREIGN KEY (id)
        REFERENCES kadry.stanow (id);
/
ALTER TABLE kadry.staztab_c
    ADD CONSTRAINT staztab_c_staztab FOREIGN KEY (id)
        REFERENCES kadry.staztab (id);
/
ALTER TABLE kadry.typum_c
    ADD CONSTRAINT typum_c_typum_fk FOREIGN KEY (id)
        REFERENCES kadry.typum (id);
/
ALTER TABLE kadry.umowy_c
    ADD CONSTRAINT umowy_c_umowy_fk FOREIGN KEY (id)
        REFERENCES kadry.umowy (id);
/
-------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------- TRIGGERY
--------------------------- PRAC_PRACC_AUD
create or replace NONEDITIONABLE TRIGGER prac_pracc_aud
    AFTER UPDATE OR DELETE
    ON pracownicy
    FOR EACH ROW
DECLARE
    t_rec INTEGER;
BEGIN
    IF (:NEW.imie <> :OLD.imie or :NEW.nazwisko <> :OLD.nazwisko or :NEW.pesel <> :OLD.pesel or
        :NEW.dok_typ <> :OLD.dok_typ or :NEW.nr_dok <> :OLD.nr_dok or :NEW.id_misc <> :OLD.id_misc or
        :NEW.ulica <> :OLD.ulica or :NEW.nr_dom <> :OLD.nr_dom or :NEW.nr_lok <> :OLD.nr_lok) THEN
        t_rec := SYS_GUID();
        INSERT INTO pracownicy_c (C_ID, C_DATA, C_OPER, ID, IMIE, NAZWISKO, PESEL, DOK_TYP, NR_DOK, ID_MISC, ULICA,
                                  NR_DOM, NR_LOK)
        VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), 1, :OLD.id, :OLD.imie, :OLD.NAZWISKO, :OLD.PESEL,
                :OLD.DOK_TYP, :OLD.NR_DOK, :OLD.ID_MISC, :OLD.ULICA,
                :OLD.NR_DOM, :OLD.NR_LOK);
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;
/
/*
--------------------------- ABSE_ABSEC_AUD
create or replace NONEDITIONABLE TRIGGER abse_absec_aud
    AFTER UPDATE OR DELETE
    ON absencje
    FOR EACH ROW
DECLARE
    t_rec INTEGER;
BEGIN
    IF (:NEW.dtod <> :OLD.dtod or :NEW.dtdo <> :OLD.dtdo or :NEW.id_typobec <> :OLD.id_typobec or
        :NEW.id_prc <> :OLD.id_prc or :NEW.id_ump <> :OLD.id_ump or :NEW.zada <> :OLD.zada) THEN
        t_rec := absencje_c_seq.NEXTVAL;
        INSERT INTO absencje_c (c_id, c_data, c_oper, id, dtod, dtdo, id_typobec, id_prc, id_ump, zada)
        VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), 1, :OLD.id, :OLD.dtod, :OLD.dtdo, :OLD.id_typobec,
                :OLD.id_prc, :OLD.id_ump, :OLD.zada);
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;
/
*/
--------------------------- ADRESY_ADRESYC_AUD
-- create or replace NONEDITIONABLE TRIGGER adresy_adresyc_aud
--     AFTER UPDATE OR DELETE
--     ON adresy
--     FOR EACH ROW
-- DECLARE
--     t_rec INTEGER;
-- BEGIN
--     IF (:NEW.misc <> :OLD.misc or :NEW.gmina <> :OLD.gmina or :NEW.powiat <> :OLD.powiat or
--         :NEW.wojew <> :OLD.wojew or :NEW.teryt <> :OLD.teryt or :NEW.kod_pocz <> :OLD.kod_pocz) THEN
--         t_rec := adresy_c_seq.NEXTVAL;
--         INSERT INTO adresy_c (c_id, c_data, c_oper, id, misc, gmina, powiat, wojew, teryt, kod_pocz)
--         VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), 1, :OLD.id, :OLD.misc, :OLD.gmina, :OLD.powiat,
--                 :OLD.wojew, :OLD.teryt, :OLD.kod_pocz);
--     END IF;
-- EXCEPTION
--     WHEN OTHERS THEN
--         raise_application_error(-20002, SQLERRM);
-- END;
/*
--------------------------- HPS_HPSC_AUD
create or replace NONEDITIONABLE TRIGGER hps_hpsc_aud
    AFTER UPDATE OR DELETE
    ON hps
    FOR EACH ROW
DECLARE
    t_rec INTEGER;
BEGIN
    IF (:NEW.dtod <> :OLD.dtod or :NEW.dtdo <> :OLD.dtdo or :NEW.stog <> :OLD.stog or
        :NEW.stzw <> :OLD.stzw or :NEW.stws <> :OLD.stws or :NEW.stjb <> :OLD.stjb or
        :NEW.id_prc <> :OLD.id_prc) THEN
        t_rec := hps_c_seq.NEXTVAL;
        INSERT INTO hps_c (c_id, c_data, c_oper, id, dtod, dtdo, stog, stzw, stws, stjb, id_prc)
        VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), 1, :OLD.id, :OLD.dtod, :OLD.dtdo, :OLD.stog,
                :OLD.stzw, :OLD.stws, :OLD.stjb, :OLD.id_prc);
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;
/
*/
--------------------------- OKRESY_OKRESYC_AUD
create or replace
TRIGGER okresy_okresyc_aud
     AFTER UPDATE OR DELETE
     ON okresy
     FOR EACH ROW
 DECLARE
     t_rec RAW(32);
 BEGIN
     IF (:NEW.dtod <> :OLD.dtod or :NEW.dtdo <> :OLD.dtdo or :NEW.dni_kal <> :OLD.dni_kal or
         :NEW.dni_rob <> :OLD.dni_rob or :NEW.norma <> :OLD.norma) THEN
         t_rec := SYS_GUID();
         INSERT INTO okresy_c (c_id, c_data, c_oper, id, dtod, dtdo, dni_kal, dni_rob, norma)
         VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), t_rec, :OLD.id, :OLD.dtod, :OLD.dtdo, :OLD.dni_kal, :OLD.dni_rob, :OLD.norma);
     END IF;
 EXCEPTION
     WHEN OTHERS THEN
         raise_application_error(-20002, SQLERRM);
 END;
/
-------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------- FUNCKJE

--------------------------- F_HOURS_TO_MIN

CREATE OR REPLACE FUNCTION F_HOURS_TO_MIN(WART NUMBER)
    RETURN NUMBER
    IS
BEGIN
    RETURN round(WART * 60);
END;

--------------------------- F_ MIN_TO_HOURS

create or replace FUNCTION F_MIN_TO_HOURS(
    WART NUMBER
)
    RETURN NUMBER
    IS
BEGIN
    RETURN round(WART / 60);
END;

create or replace FUNCTION GUID_TO_RAW(
    GUID VARCHAR2
)
    RETURN RAW
    IS
BEGIN
    RETURN hextoraw(substr(GUID, 7, 2) ||
                    substr(GUID, 5, 2) ||
                    substr(GUID, 3, 2) ||
                    substr(GUID, 1, 2) ||
                    substr(GUID, 12, 2) ||
                    substr(GUID, 10, 2) ||
                    substr(GUID, 17, 2) ||
                    substr(GUID, 15, 2) ||
                    substr(GUID, 20, 4) ||
                    substr(GUID, 25, 12)
        );
END;

-------------------------------------------------------------------------------------------------------------------

------------------------------------------------------------------- PAKIETY (PACKAGE)

--------------------------- OPER_SECURITY

----- PACKAGE
    create or replace NONEDITIONABLE PACKAGE oper_security AS
    FUNCTION get_hash(login IN VARCHAR2,
                      passw IN VARCHAR2)
        RETURN VARCHAR2;
    PROCEDURE add_oper(id IN RAW, login IN VARCHAR2, passw IN VARCHAR2, imie IN VARCHAR2, nazwisko IN VARCHAR2);
END;

----- BODY
    create or replace NONEDITIONABLE PACKAGE BODY oper_security AS
    FUNCTION get_hash(login IN VARCHAR2,
                      passw IN VARCHAR2)
        RETURN VARCHAR2 AS
        l_salt VARCHAR2(30) := 'SD34!';
    BEGIN
        RETURN DBMS_CRYPTO.HASH(UTL_RAW.CAST_TO_RAW(UPPER(login) || l_salt || UPPER(passw)), DBMS_CRYPTO.HASH_SH1);
    END;
    PROCEDURE add_oper(id IN RAW, login IN VARCHAR2, passw IN VARCHAR2, imie IN VARCHAR2, nazwisko IN VARCHAR2) AS
    BEGIN
        INSERT INTO oper (id, imie, nazwisko, login, passw)
        VALUES (id, imie, nazwisko, UPPER(login), get_hash(login, passw));
        COMMIT;
    END;
END;

--------------------------- PKZP

----- PACKAGE

CREATE OR REPLACE PACKAGE pkzp_pack AS
    FUNCTION f_pkzp_sklad(v_froma VARCHAR2, v_sklad VARCHAR2, v_idumowy NUMBER) RETURN NUMBER;
END;

----- BODY

CREATE OR REPLACE PACKAGE BODY pkzp_pack AS
    FUNCTION f_pkzp_sklad(v_froma VARCHAR2, v_sklad VARCHAR2, v_idumowy NUMBER)
        RETURN NUMBER AS
        v_kwota FLOAT;
        v_buf   FLOAT;
    BEGIN
        IF (v_froma = 0) THEN
            SELECT zasad * (v_sklad / 100)
            INTO v_kwota
            FROM umowy
            WHERE id = v_idumowy;
        ELSIF (v_froma = 1) THEN
            v_kwota := v_sklad;
        END IF;
        RETURN (v_kwota);
    END;
END;