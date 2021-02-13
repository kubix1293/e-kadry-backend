------------------------------------------------------------------- TABELS
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
    id       RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    id_prc   RAW(32)                      NOT NULL,
    saldo    FLOAT(15) DEFAULT 0,
    dt       FLOAT(15) DEFAULT 0,
    ct       FLOAT(15) DEFAULT 0,
    rodz     NUMBER                       NOT NULL,
    pkzp_poz RAW(32),
    zamk     NUMBER(1)
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
10 - wkłady
20 - pożyczka';
/
COMMENT ON COLUMN kadry.pkzp.zamk IS
    'czy zamknięta pożyczka';
/
ALTER TABLE kadry.pkzp
    ADD CONSTRAINT pkzp_pk PRIMARY KEY (id);
/

------  PKZP_POZ
CREATE TABLE kadry.pkzp_poz
(
    id        RAW(32)   DEFAULT SYS_GUID()   NOT NULL,
    rodz      NUMBER                         NOT NULL,
    kwot      FLOAT(15) DEFAULT 0            NOT NULL,
    id_oks    RAW(32)                        NOT NULL,
    id_prc    RAW(32)                        NOT NULL,
    pkzp_poz  RAW(32),
    zamk      NUMBER(1) DEFAULT 0,
    utworzony DATE      DEFAULT current_date NOT NULL
);
/
COMMENT ON COLUMN kadry.pkzp_poz.rodz IS
    'Rodzaj PKZP
10 - wkład
20 - pożyczka
30 - wpisowe
40 - spłata
50 - saldo poczatkowe';
/
COMMENT ON COLUMN kadry.pkzp_poz.kwot IS
    'Kwota spłaty lub wkładu ';
/
ALTER TABLE kadry.pkzp_poz
    ADD CONSTRAINT pkzp_poz_pk PRIMARY KEY (id);
/

------  PKZP_HARM
CREATE TABLE kadry.pkzp_harm
(
    id      RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    kwot    FLOAT(15) DEFAULT 0          NOT NULL,
    okres   VARCHAR2(7)                  NOT NULL,
    id_pkzp RAW(32)                      NOT NULL,
    id_oks  RAW(32)                      NOT NULL,
    zamk    NUMBER    DEFAULT 0          NOT NULL
);
/
COMMENT ON COLUMN kadry.pkzp_harm.kwot IS
    'Kwota raty ';
/
COMMENT ON COLUMN kadry.pkzp_harm.zamk IS
    'Czy pozycja zamknięta, zatwierdzona
    0 - otwarte
    1 - zamknięte';
/
COMMENT ON COLUMN kadry.pkzp_harm.okres IS
    'okres spłaty danej raty np: 01-2021';
/
ALTER TABLE kadry.pkzp_harm
    ADD CONSTRAINT pkzp_harm_pk PRIMARY KEY (id);
/

------ PKZP_SKLAD
CREATE TABLE kadry.pkzp_sklad
(
    id      RAW(32) DEFAULT SYS_GUID() NOT NULL,
    id_prc  RAW(32)                    NOT NULL,
    sklad   FLOAT(10)                  NOT NULL,
    dakt    DATE    DEFAULT sysdate    NOT NULL
);
/
COMMENT ON COLUMN kadry.pkzp_sklad.sklad IS
    'Kwota miesięcznej składki';
/
COMMENT ON COLUMN kadry.pkzp_sklad.dakt IS
    'Data aktualizacji';
/
ALTER TABLE kadry.pkzp_sklad
    ADD CONSTRAINT pkzp_sklad_pk PRIMARY KEY (id);
/

------ PKZP_PARAM
CREATE TABLE kadry.pkzp_param
(
    forma       NUMBER(1) DEFAULT 1  NOT NULL,
    ile_rat     NUMBER(2) DEFAULT 12 NOT NULL,
    wpis        FLOAT(10) DEFAULT 0  NOT NULL,
    sklad_min   FLOAT(10) DEFAULT 0  NOT NULL,
    sklad_max   FLOAT(10) DEFAULT 0  NOT NULL,
    kwot_max    FLOAT(10) DEFAULT 0  NOT NULL,
    wklad_min   FLOAT(10) DEFAULT 0  NOT NULL   
);
/
COMMENT ON COLUMN kadry.pkzp_param.forma IS
    'Forma składek  0 - %,  1 - zł';
/
COMMENT ON COLUMN kadry.pkzp_param.wpis IS
    'wartość wpisowego początkowego';
/
COMMENT ON COLUMN kadry.pkzp_param.sklad_min IS
    'wartość minimalna składki PKZP';
/
COMMENT ON COLUMN kadry.pkzp_param.sklad_max IS
    'wartość maksymalna składki PKZP';
/
COMMENT ON COLUMN kadry.pkzp_param.kwot_max IS
    'maksymalna wysokość udzielanej pożyczki';
/
COMMENT ON COLUMN kadry.pkzp_param.wklad_min IS
    'minimalna wysokość wkładów od których można wziąć pożyczkę';        
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
    dok_typ        NUMBER,
    nr_dok         VARCHAR(20),
    plec           INTEGER,
    ulica          VARCHAR2(50),
    nr_dom         VARCHAR2(10),
    nr_lok         VARCHAR2(10),
    kod_pocz       VARCHAR2(10),
    miasto         VARCHAR2(50),
    kraj           VARCHAR2(50),
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
    nazwa   VARCHAR2(155),
    kod_gus NUMBER(10)
);
/
ALTER TABLE kadry.stanow
    ADD CONSTRAINT stanow_pk PRIMARY KEY (id);
/
------ UMOWY
CREATE TABLE kadry.umowy
(
    id             RAW(32)   DEFAULT SYS_GUID()   NOT NULL,
    dtzaw          DATE                           NOT NULL,
    dtroz          DATE,
    zasad          FLOAT(15) DEFAULT 0            NOT NULL,
    id_stanow      RAW(32)                        NOT NULL,
    id_prc         RAW(32)                        NOT NULL,
    nr_tyt_zus     NUMBER(5),
    etatl          NUMBER(3),
    etatm          NUMBER(3),
    czy_chor       NUMBER(1) DEFAULT 0            NOT NULL,
    czy_ren        NUMBER(1) DEFAULT 0            NOT NULL,
    czy_emer       NUMBER(1) DEFAULT 0            NOT NULL,
    czy_zdrow      NUMBER(1) DEFAULT 0            NOT NULL,
    czy_fp         NUMBER(1) DEFAULT 0            NOT NULL,
    czy_fgsp       NUMBER(1) DEFAULT 0            NOT NULL,
    czy_urlop      NUMBER(1) DEFAULT 0            NOT NULL,
    czy_ab_chor    NUMBER(1) DEFAULT 0            NOT NULL,
    czy_pkzp       NUMBER(1) DEFAULT 0            NOT NULL,
    nrm_czas_prac  FLOAT(15),
    stog           NUMBER(1) DEFAULT 0            NOT NULL,
    stzw           NUMBER(1) DEFAULT 0            NOT NULL,
    stws           NUMBER(1) DEFAULT 0            NOT NULL,
    stjb           NUMBER(1) DEFAULT 0            NOT NULL,
    usuniety       DATE,
    utworzony      DATE      DEFAULT current_date NOT NULL,
    zaktualizowany DATE      DEFAULT current_date NOT NULL
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
    ulica    VARCHAR2(50),
    nr_dom   VARCHAR2(10),
    nr_lok   VARCHAR2(10),
    kod_pocz VARCHAR2(10),
    miasto   VARCHAR2(50),
    kraj     VARCHAR2(50),
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
    c_id      RAW(32)   DEFAULT SYS_GUID()   NOT NULL,
    c_data    DATE      DEFAULT sysdate      NOT NULL,
    c_oper    RAW(32)                        NOT NULL,
    id        RAW(32)                        NOT NULL,
    rodz      NUMBER                         NOT NULL,
    kwot      FLOAT(15) DEFAULT 0            NOT NULL,
    ile_rat   NUMBER    DEFAULT NULL,
    id_pkzp   RAW(32)                        NOT NULL,
    id_oks    RAW(32)                        NOT NULL,
    zamk      NUMBER    DEFAULT 0            NOT NULL,
    utworzony DATE      DEFAULT current_date NOT NULL
);
/
ALTER TABLE kadry.pkzp_poz_c
    ADD CONSTRAINT pkzp_poz_c_pk PRIMARY KEY (c_id);
/

------  PKZP_HARM_C
CREATE TABLE kadry.pkzp_harm_c
(
    c_id    RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE      DEFAULT sysdate    NOT NULL,
    c_oper  RAW(32)                      NOT NULL,
    id      RAW(32)                      NOT NULL,
    kwot    FLOAT(15) DEFAULT 0          NOT NULL,
    id_pkzp RAW(32)                      NOT NULL,
    okres   DATE                         NOT NULL,
    zamk    NUMBER    DEFAULT 0          NOT NULL
);
/
ALTER TABLE kadry.pkzp_harm_c
    ADD CONSTRAINT pkzp_harm_c_pk PRIMARY KEY (c_id);
/

------  PKZP_SKLAD_C
CREATE TABLE kadry.pkzp_sklad_c
(
    c_id    RAW(32)   DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE      DEFAULT sysdate    NOT NULL,
    c_oper  RAW(32)                      NOT NULL,
    id      RAW(32)                     NOT NULL,
    id_prc  RAW(32)                    NOT NULL,
    sklad   FLOAT(10)                  NOT NULL,
    dakt    DATE    DEFAULT sysdate    NOT NULL
);
/
ALTER TABLE kadry.pkzp_sklad_c
    ADD CONSTRAINT pkzp_sklad_c_pk PRIMARY KEY (id);
/

------ STANOW_C (STANOWISKA)
CREATE TABLE kadry.stanow_c
(
    c_id    RAW(32) DEFAULT SYS_GUID() NOT NULL,
    c_data  DATE    DEFAULT sysdate    NOT NULL,
    c_oper  RAW(32)                    NOT NULL,
    id      RAW(32)                    NOT NULL,
    nazwa   VARCHAR2(155),
    kod_gus NUMBER(10)
);
/
ALTER TABLE kadry.stanow_c
    ADD CONSTRAINT stanow_c_pk PRIMARY KEY (id);
/

------ UMOWY_C
CREATE TABLE kadry.umowy_c
(
    c_id           RAW(32)   DEFAULT SYS_GUID()   NOT NULL,
    c_data         DATE      DEFAULT sysdate      NOT NULL,
    c_oper         RAW(32)                        NOT NULL,
    id             RAW(32)                        NOT NULL,
    dtzaw          DATE                           NOT NULL,
    dtroz          DATE,
    zasad          FLOAT(15) DEFAULT 0            NOT NULL,
    id_stanow      RAW(32)                        NOT NULL,
    id_prc         RAW(32)                        NOT NULL,
    nr_tyt_zus     NUMBER(5),
    czy_chor       NUMBER(1) DEFAULT 0            NOT NULL,
    czy_ren        NUMBER(1) DEFAULT 0            NOT NULL,
    czy_emer       NUMBER(1) DEFAULT 0            NOT NULL,
    czy_zdrow      NUMBER(1) DEFAULT 0            NOT NULL,
    czy_fp         NUMBER(1) DEFAULT 0            NOT NULL,
    czy_fgsp       NUMBER(1) DEFAULT 0            NOT NULL,
    czy_urlop      NUMBER(1) DEFAULT 0            NOT NULL,
    czy_ab_chor    NUMBER(1) DEFAULT 0            NOT NULL,
    nrm_czas_prac  FLOAT(15),
    stog           NUMBER(1) DEFAULT 0            NOT NULL,
    stzw           NUMBER(1) DEFAULT 0            NOT NULL,
    stws           NUMBER(1) DEFAULT 0            NOT NULL,
    stjb           NUMBER(1) DEFAULT 0            NOT NULL,
    usuniety       DATE,
    utworzony      DATE      DEFAULT current_date NOT NULL,
    zaktualizowany DATE      DEFAULT current_date NOT NULL
);
/
ALTER TABLE kadry.umowy_c
    ADD CONSTRAINT umowy_c_pk PRIMARY KEY (c_id);
/
-------------------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------  CONSTRAINTS
ALTER TABLE kadry.pkzp_harm
    ADD CONSTRAINT pkzpharm_pkzppoz_fk FOREIGN KEY (id_pkzp)
        REFERENCES kadry.pkzp_poz (id);
/
ALTER TABLE kadry.pkzp
    ADD CONSTRAINT pkzp_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.pkzp_poz
    ADD CONSTRAINT pkzppoz_pracwnicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.pkzp_poz
    ADD CONSTRAINT pkzppoz_okresy_fk FOREIGN KEY (id_oks)
        REFERENCES kadry.okresy (id);
/
ALTER TABLE kadry.pkzp
    ADD CONSTRAINT pkzp_pkzppoz_fk FOREIGN KEY (pkzp_poz)
        REFERENCES kadry.pkzp_poz (id);
/
ALTER TABLE kadry.pkzp_sklad
    ADD CONSTRAINT pkzpsklad_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);        
/
ALTER TABLE kadry.pracownicy
    ADD CONSTRAINT pracownicy_oper_fk FOREIGN KEY (id_oper)
        REFERENCES kadry.oper (id);
/
ALTER TABLE kadry.umowy
    ADD CONSTRAINT umowy_pracownicy_fk FOREIGN KEY (id_prc)
        REFERENCES kadry.pracownicy (id);
/
ALTER TABLE kadry.umowy
    ADD CONSTRAINT umowy_stanow_fk FOREIGN KEY (id_stanow)
        REFERENCES kadry.stanow (id);
/
ALTER TABLE kadry.pracownicy_c
    ADD CONSTRAINT pracownicy_c_prac_fk FOREIGN KEY (id)
        REFERENCES kadry.pracownicy (id);
/
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
ALTER TABLE kadry.pkzp_harm_c
    ADD CONSTRAINT pkzpharm_c_pkzpharm_fk FOREIGN KEY (id)
        REFERENCES kadry.pkzp_harm (id);
/
ALTER TABLE kadry.pkzp_sklad_c
    ADD CONSTRAINT pkzpsklad_c_pkzpsklad_fk FOREIGN KEY (id)
        REFERENCES kadry.pkzp_sklad (id);
/
ALTER TABLE kadry.pkzp_poz_c
    ADD CONSTRAINT pkzp_poz_c_pkzp_poz_fk FOREIGN KEY (id)
        REFERENCES kadry.pkzp_poz (id);
/
ALTER TABLE kadry.stanow_c
    ADD CONSTRAINT stanow_c_stanow_fk FOREIGN KEY (id)
        REFERENCES kadry.stanow (id);
/
ALTER TABLE kadry.umowy_c
    ADD CONSTRAINT umowy_c_umowy_fk FOREIGN KEY (id)
        REFERENCES kadry.umowy (id);
/
-------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------- VIEWS
--------------------------- PKZP_SPLATY

CREATE VIEW pkzp_splaty AS
SELECT p.id as id_prc, p.imie, p.nazwisko, ph.kwot, pk.id as id_pkzppoz, ph.zamk
FROM kadry.pracownicy p
         JOIN kadry.pkzp_poz pk ON p.id = pk.id_prc
         JOIN kadry.pkzp_harm ph ON pk.id = ph.id_pkzp;

-------------------------------------------------------------------------------------------------------------------
------------------------------------------------------------------- TRIGGERY
--------------------------- PRAC_PRACC_AUD
create or replace
    TRIGGER kadry.prac_pracc_aud
    AFTER UPDATE OR DELETE
    ON kadry.pracownicy
    FOR EACH ROW
DECLARE
    t_rec RAW(32);
BEGIN
    IF (:NEW.imie <> :OLD.imie or :NEW.nazwisko <> :OLD.nazwisko or :NEW.pesel <> :OLD.pesel or
        :NEW.dok_typ <> :OLD.dok_typ or :NEW.nr_dok <> :OLD.nr_dok or
        :NEW.ulica <> :OLD.ulica or :NEW.nr_dom <> :OLD.nr_dom or :NEW.nr_lok <> :OLD.nr_lok or 
        :NEW.kod_pocz <> :OLD.kod_pocz or :NEW.miasto <> :OLD.miasto or :NEW.kraj <> :OLD.kraj) THEN
            t_rec := SYS_GUID();
            INSERT INTO kadry.pracownicy_c (C_ID, C_DATA, C_OPER, ID, IMIE, NAZWISKO, PESEL, DOK_TYP, NR_DOK, ULICA, 
            NR_DOM, NR_LOK, KOD_POCZ, MIASTO, KRAJ)
            VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), t_rec, :OLD.id, :OLD.imie, :OLD.NAZWISKO, :OLD.PESEL, 
            :OLD.DOK_TYP, :OLD.NR_DOK, :OLD.ULICA,
            :OLD.NR_DOM, :OLD.NR_LOK, :OLD.kod_pocz, :OLD.miasto, :OLD.kraj);
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;
/

--------------------------- OKRESY_OKRESYC_AUD
create or replace
    TRIGGER kadry.okresy_okresyc_aud
    AFTER UPDATE OR DELETE
    ON kadry.okresy
    FOR EACH ROW
DECLARE
    t_rec RAW(32);
BEGIN
    IF (:NEW.dtod <> :OLD.dtod or :NEW.dtdo <> :OLD.dtdo or :NEW.dni_kal <> :OLD.dni_kal or
        :NEW.dni_rob <> :OLD.dni_rob or :NEW.norma <> :OLD.norma) THEN
        t_rec := SYS_GUID();
        INSERT INTO kadry.okresy_c (c_id, c_data, c_oper, id, dtod, dtdo, dni_kal, dni_rob, norma)
        VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), t_rec, :OLD.id, :OLD.dtod, :OLD.dtdo, 
        :OLD.dni_kal, :OLD.dni_rob, :OLD.norma);
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;
/

--------------------------- UMOWY_PKZPSPLA_AUD

create or replace TRIGGER kadry.umowy_pkzpspla_aui
    AFTER UPDATE OR INSERT
    ON kadry.umowy
    FOR EACH ROW
DECLARE
    lTrue NUMBER;
    lSkladMin NUMBER;
    CURSOR c_pkzp IS
        SELECT 1
        FROM pkzp_sklad
        WHERE id_prc = :NEW.id_prc;
    CURSOR c_param IS
        SELECT sklad_min
        FROM pkzp_param;
BEGIN
    IF(:NEW.czy_pkzp = 1) THEN
        OPEN c_pkzp;
        FETCH c_pkzp INTO lTrue; 
        CLOSE c_pkzp;
        IF (lTrue IS null) THEN
            OPEN c_param;
            FETCH c_param INTO lSkladMin; 
            CLOSE c_param;
            ---
            INSERT INTO pkzp_sklad (id_prc, sklad)
            VALUES (:NEW.id_prc, lSkladMin);
        ELSE
            NULL;
        END IF;
    ELSE
        NULL;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;


--------------------------- PKZPSKLAD_PKZPSKLADC_AUD
create or replace
    TRIGGER kadry.pkzpsklad_pkzpskladc_aud
    AFTER UPDATE OR DELETE
    ON kadry.pkzp_sklad
    FOR EACH ROW
DECLARE
    t_rec RAW(32);
BEGIN
    IF (:NEW.id_prc <> :OLD.id_prc or :NEW.sklad <> :OLD.sklad ) THEN
        t_rec := SYS_GUID();
        INSERT INTO kadry.pkzp_sklad_c (c_id, c_data, c_oper, id, id_prc, sklad, dakt)
        VALUES (t_rec, to_date(sysdate, 'yyyy-mm-dd HH24:MI:SS'), t_rec, :OLD.id, :OLD.id_prc, :OLD.sklad, 
        :OLD.dakt);
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;
/

--------------------------- PKZP_BI

create or replace TRIGGER pkzp_bi
    BEFORE INSERT
    ON kadry.pkzp
    FOR EACH ROW
DECLARE
    rec RAW(32);
    CURSOR c_id IS
        SELECT id_prc
        FROM pkzp
        WHERE rodz = 10
          AND id_prc = :NEW.id_prc;
BEGIN
    IF (:NEW.rodz = 10) THEN
        OPEN c_id;
        FETCH c_id INTO rec;
        CLOSE c_id;
        IF (rec IS NOT NULL) THEN
            raise_application_error(-20002, SQLERRM || 'WKŁADY JUŻ ISTNIEJĄ');
        END IF;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;

--------------------------- PKZPSKLAD_BI

create or replace
TRIGGER pkzpsklad_bi
    BEFORE INSERT
    ON kadry.pkzp_sklad
    FOR EACH ROW
DECLARE
    lTrue RAW(32);
    lSkladMin NUMBER;
    lSkladMax NUMBER;
    CURSOR c_prc IS
        SELECT id
        FROM pkzp_sklad
        WHERE id_prc = :NEW.id_prc;
    CURSOR c_param IS
        SELECT sklad_min, sklad_max
        FROM pkzp_param;
BEGIN
    OPEN c_prc;
    FETCH c_prc INTO lTrue;
    CLOSE c_prc;
    IF ( lTrue IS NOT NULL) THEN
        raise_application_error(-20002, 'PRACOWNIK MA JUZ WPIS DOTYCZACY SKLADKI');
    ELSE
        OPEN c_param;
        FETCH c_param INTO lSkladMin, lSkladMax;
        CLOSE c_param;
        IF (lSkladMin = 0 AND lSkladMax = 0) THEN
            NULL;
        END IF;    
        IF (lSkladMin > 0) THEN
            IF(:NEW.sklad < lSkladMin) THEN
                raise_application_error(-20002, 'SKŁADKA NIE MOŻE BYĆ MNIEJSZA NIŻ KWOTA MINIMALNA W PARAMETRACH');
            END IF;
        END IF;
        IF (lSkladMax > 0) THEN
            IF(:NEW.sklad > lSkladMax) THEN
                raise_application_error(-20002, 'SKŁADKA NIE MOŻE BYĆ WIĘKSZA NIŻ KWOTA MAKSYMALNA W PARAMETRACH');
            END IF;
        END IF;
    END IF;
END;


--------------------------- PKZPPOZ_PKZP_AI

create or replace
TRIGGER kadry.pkzppoz_pkzp_ai
    AFTER INSERT
    ON kadry.pkzp_poz
    FOR EACH ROW
DECLARE
    rec RAW(32);
    lZamk NUMBER;
    CURSOR c_id IS
        SELECT id_prc
        FROM kadry.pkzp
        WHERE rodz = 10
        AND id_prc = :NEW.id_prc;
BEGIN
    IF (:NEW.rodz = 20) THEN
        INSERT INTO kadry.pkzp (id_prc, dt, saldo, rodz, pkzp_poz, zamk)
        VALUES (:NEW.id_prc, :NEW.kwot, 0 - :NEW.kwot, :NEW.rodz, :NEW.id, 0);
    END IF;
    IF (:NEW.rodz = 10 or :NEW.rodz = 50) THEN
        OPEN c_id;
        FETCH c_id INTO rec;
        CLOSE c_id;
        IF (rec IS NOT NULL) THEN
            UPDATE kadry.pkzp
            SET ct    = ct + :NEW.kwot,
                saldo = saldo + :NEW.kwot
            WHERE id_prc = :NEW.id_prc
              AND rodz = 10;
        ELSE
            INSERT INTO kadry.pkzp (id_prc, ct, saldo, rodz, pkzp_poz)
            VALUES (:NEW.id_prc, :NEW.kwot, :NEW.kwot, 10, :NEW.id);
        END IF;
    END IF;
    IF (:NEW.rodz = 40) THEN
            UPDATE kadry.pkzp 
            SET ct = ct + :NEW.kwot,
                saldo = saldo + :NEW.kwot
            WHERE id_prc = :NEW.id_prc
            AND rodz = 20
            AND pkzp_poz = :NEW.pkzp_poz;
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        raise_application_error(-20002, SQLERRM);
END;

--------------------------- PKZPHARM_PKZPPOZ_AU
create or replace TRIGGER kadry.pkzpharm_pkzppoz_au
    AFTER UPDATE
    ON kadry.pkzp_harm
    FOR EACH ROW
DECLARE
    lIdprc RAW(32);
    lZamk NUMBER;
    CURSOR c_prc IS
      SELECT id_prc, saldo
      FROM pkzp
      WHERE pkzp_poz = :NEW.id_pkzp
      AND rodz = 20;
BEGIN
    IF (:NEW.zamk = 1) THEN
        OPEN c_prc;
        FETCH c_prc INTO lIdprc, lZamk;
        CLOSE c_prc;
        --
        IF (lZamk + :NEW.kwot >= 0) THEN
          UPDATE pkzp SET zamk = 1
          WHERE pkzp_poz = :NEW.id_pkzp;
        ELSE
          NULL;
        END IF;
        --
        INSERT INTO pkzp_poz (kwot, rodz, id_oks, id_prc, pkzp_poz)
        VALUES (:NEW.kwot, 40, :NEW.id_oks, lIdprc, :NEW.id_pkzp);
    END IF;
END;

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

--------------------------- GUID_TO_RAW

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
    FUNCTION get_hash(login IN VARCHAR2, passw IN VARCHAR2) RETURN VARCHAR2;
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

create or replace
    PACKAGE pkzp_pack AS
    FUNCTION f_pkzp_sklad(iForma VARCHAR2, iSklad NUMBER, iIdumowy RAW) RETURN NUMBER;
    FUNCTION f_pkzp_wpis(iForma VARCHAR2, iWpis NUMBER, iIdumowy RAW) RETURN NUMBER;
    FUNCTION f_pkzp_pozyczka(iIdprc RAW, iKwota FLOAT DEFAULT 0, iIlerat NUMBER DEFAULT 0, iRata FLOAT DEFAULT 0) RETURN FLOAT;
    PROCEDURE pkzp_insert(iIdpkzppoz RAW, iRodz NUMBER, iIdoks RAW, iIdprc RAW, iKwota FLOAT DEFAULT 0, iIlerat NUMBER DEFAULT 0, iRata FLOAT DEFAULT 0);
    PROCEDURE pkzp_harmo(iIdpkzppoz RAW, lRata FLOAT, iIlerat NUMBER, iIdoks RAW);
    PROCEDURE pkzp_splaty(iIdpkzppoz RAW, iKwota FLOAT, iRodz NUMBER, iIdprc RAW, iIdoks RAW, iZamk NUMBER DEFAULT 0);
END;


----- BODY

create or replace PACKAGE BODY pkzp_pack AS
    FUNCTION f_pkzp_sklad(iForma VARCHAR2, iSklad NUMBER, iIdumowy RAW)
        RETURN NUMBER AS
        lKwota FLOAT;
    BEGIN
        IF (iForma = 0) THEN
            SELECT zasad * (iSklad / 100)
            INTO lKwota
            FROM umowy
            WHERE id = iIdumowy;
        ELSIF (iForma = 1) THEN
            lKwota := iSklad;
        END IF;
        RETURN (lKwota);
    END;
    ----
    FUNCTION f_pkzp_wpis(iForma VARCHAR2, iWpis NUMBER, iIdumowy RAW)
        RETURN NUMBER AS
        lKwota FLOAT;
    BEGIN
        IF (iForma = 0) THEN
            SELECT zasad * (iWpis / 100)
            INTO lKwota
            FROM umowy
            WHERE id = iIdumowy;
        ELSIF (iForma = 1) THEN
            lKwota := iWpis;
        END IF;
        RETURN (lKwota);
    END;
    ----
    FUNCTION f_pkzp_pozyczka(iIdprc RAW, iKwota FLOAT DEFAULT 0, iIlerat NUMBER DEFAULT 0, iRata FLOAT DEFAULT 0)
        RETURN FLOAT AS
        lSumaWkladow pkzp.ct%TYPE;
        lZasad       umowy.zasad%TYPE;
        lRata        FLOAT;
        lCt          FLOAT;
        CURSOR c_pkzp IS
          SELECT ct
          FROM pkzp WHERE id_prc = iIdprc;
    BEGIN
        IF (iIdprc > 0) THEN
            SELECT SUM(zasad)
            INTO lZasad
            FROM umowy
            WHERE id_prc = iIdprc
              AND dtzaw <= sysdate
              AND (dtroz > sysdate OR dtroz IS null)
              AND czy_pkzp = 1;
            --
            OPEN c_pkzp;
            FETCH c_pkzp INTO lCt;
            CLOSE c_pkzp;
            IF (lCt > 0) THEN
                IF (iKwota > 0 AND iIlerat > 0) THEN
                    IF (iKwota <= 3 * lZasad OR iKwota <= 3 * lSumaWkladow) THEN
                        lRata := ROUND(iKwota / iIlerat, -1);
                    ELSE
                        RAISE_APPLICATION_ERROR(-20201, 'WYSOKOSC POŻYCZKI JEST ZA DUŻA W ODNIESNIU DO ZAROBKÓW LUB WKŁADÓW');    
                    END IF;
                END IF;
                IF (iKwota > 0 AND iRata > 0) THEN
                    IF (iKwota <= 3 * lZasad OR iKwota <= 3 * lSumaWkladow) THEN
                        lRata := ROUND(iKwota / iRata, 0);
                    END IF;
                END IF;
            ELSE
                RAISE_APPLICATION_ERROR(-20201, 'BRAK WKŁADÓW');
            END IF;
        END IF;
        RETURN (lRata);
    END;
    PROCEDURE pkzp_insert(iIdpkzppoz RAW, iRodz NUMBER, iIdoks RAW, iIdprc RAW, iKwota FLOAT DEFAULT 0, iIlerat NUMBER DEFAULT 0, iRata FLOAT DEFAULT 0)
        IS
        zmien NUMBER;
    BEGIN
        IF (iRodz = 20) THEN
            IF (iKwota > 0 AND iIlerat > 0) THEN
                INSERT INTO pkzp_poz(id, rodz, kwot, id_oks, id_prc)
                VALUES (iIdpkzppoz, iRodz, iKwota, iIdoks, iIdprc);
                pkzp_harmo(iIdpkzppoz, f_pkzp_pozyczka(iIdprc, iKwota, iIlerat, iRata), iIlerat, iIdoks);
            END IF;
            IF (iKwota > 0 AND iRata > 0) THEN
                INSERT INTO pkzp_poz(id, rodz, kwot, id_oks, id_prc)
                VALUES (iIdpkzppoz, iRodz, iKwota, iIdoks, iIdprc);
                pkzp_harmo(iIdpkzppoz, iRata, f_pkzp_pozyczka(iIdprc, iKwota, iIlerat, iRata), iIdoks);
            END IF;
            IF (iRata <= 0 AND iIlerat <= 0) THEN
                RAISE_APPLICATION_ERROR(-20201, 'BRAK WKŁADÓW');
            END IF;
        END IF;
        IF (iRodz = 10) THEN
            IF (iKwota > 0) THEN
                INSERT INTO pkzp_poz(id, rodz, kwot, id_oks, id_prc)
                VALUES (iIdpkzppoz, iRodz, iKwota, iIdoks, iIdprc);
            END IF;
        END IF;
        IF (iRodz = 50) THEN
            IF (iKwota > 0) THEN
                INSERT INTO pkzp_poz(id, rodz, kwot, id_oks, id_prc)
                VALUES (iIdpkzppoz, iRodz, iKwota, iIdoks, iIdprc);
            END IF;
        END IF;
    END;
    PROCEDURE pkzp_harmo(iIdpkzppoz RAW, lRata FLOAT, iIlerat NUMBER, iIdoks RAW)
        IS
        lOks   DATE;
        lIdOks  RAW(32);
        lBuf   FLOAT;
        lKwota FLOAT;
    BEGIN
        SELECT dtod
        INTO lOks
        FROM okresy
        WHERE id = iIdoks;
        --
        lBuf := lRata;
        --
        SELECT kwot
        INTO lKwota
        FROM pkzp_poz
        WHERE id = iIdpkzppoz;
        --
        IF (iIlerat > 0) THEN
            FOR i IN 1 .. iIlerat
                LOOP
                    SELECT id
                    INTO lIdOks
                    FROM okres
                    WHERE dtod = lOks 
                    IF (lKwota >= lBuf AND i < iIlerat) THEN
                        INSERT INTO pkzp_harm (kwot, id_pkzp, okres,id_oks)
                        VALUES (lRata, iIdpkzppoz, to_char(to_date(lOks, 'YYYY-MM-DD'), 'YYYY-MM'),lIdOks);
                        --
                        lOks := add_months(lOks, 1);
                        lBuf := lBuf + lRata;
                    ELSE
                        INSERT INTO pkzp_harm (kwot, id_pkzp, okres,id_oks)
                        VALUES (lRata + (lKwota - lBuf), iIdpkzppoz, to_char(to_date(lOks, 'YYYY-MM-DD'), 'YYYY-MM'),lIdOks);
                        --
                        lOks := add_months(lOks, 1);
                        lBuf := lBuf + lRata;
                    END IF;
                END LOOP;
        ELSE
            RAISE_APPLICATION_ERROR(-20201, 'BRAK WKŁADÓW');
        END IF;
        COMMIT;
    END;
    PROCEDURE pkzp_splaty(iIdpkzppoz RAW, iKwota FLOAT, iRodz NUMBER, iIdprc RAW, iIdoks RAW, iZamk NUMBER DEFAULT 0)
        IS
        lOks VARCHAR2(7);
    BEGIN
        SELECT to_char(dtod, 'YYYY-MM')
        INTO lOks
        FROM okresy
        WHERE id = iIdoks;
        --
        IF (iRodz = 30 AND iKwota > 0 AND iZamk = 1) THEN
            UPDATE pkzp_harm
            SET zamk = 1
            WHERE id_pkzp = iIdpkzppoz
              AND okres = lOks;
        ELSIF (iRodz = 10 AND iKwota > 0 AND iZamk = 1) THEN
            INSERT INTO pkzp_poz(id, rodz, kwot, id_oks, id_prc)
            VALUES (iIdpkzppoz, iRodz, iKwota, iIdoks, iIdprc);
        ELSE
            RAISE_APPLICATION_ERROR(-20201, 'BARK KTÓREGOŚ Z PARAMETRÓW');
        END IF;
    END;
END;
