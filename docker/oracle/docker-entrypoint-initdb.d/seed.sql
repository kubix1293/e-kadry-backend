--------------------------------------------------------------
----------------  PRACOWNICY

INSERT INTO KADRY.pracownicy (id, imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('8f3eacb6-5fa3-45dd-ba81-89036d328b2f', 'Jakub', 'Nowacki', to_date('1993-02-01', 'yyyy-mm-dd'), 'Leszno', '93020100012', 1, 'CJU938487', 'M', null, 'Daszyńskiego', '24',
        '5', 'A1', 'Renata', 'Władysław', '509677027', null);
/
INSERT INTO KADRY.pracownicy (id, imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('5fe1fda2-0572-4175-adee-52f3f7e5ee71', 'Paulina', 'Kwiat', to_date('1997-12-05', 'yyyy-mm-dd'), 'Leszno', '97120510124', 1, 'CLD542156', 'K', null, 'Polna', '13A', NULL,
        'A4', 'Krystyna', 'Adam', '605486689', null);
/
INSERT INTO KADRY.pracownicy (id, imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('865f4c02-209f-4389-8c18-faf6e243f172', 'Aleksander', 'Nowak', to_date('1989-09-21', 'yyyy-mm-dd'), 'Lasocice', '89092100335', 1, 'CDP945427', 'M', null, 'Kosynierów', '5',
        null, 'A2', 'Marlena', 'Adam', null, null);
/
INSERT INTO KADRY.pracownicy (id, imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('8965ed66-08c6-4752-b36c-dafc186bca0c', 'Marlena', 'Kowalska', to_date('1976-07-12', 'yyyy-mm-dd'), 'Leszno', '76071225228', 1, 'CDU765412', 'K', null, 'Niepodległości',
        '34', '12', 'A3', 'Agata', 'Bronisław', null, null);
/
INSERT INTO KADRY.pracownicy (id, imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('dca5842c-bafe-4d8d-a585-d58ab27682f5', 'Bartosz', 'Molik', to_date('1963-10-30', 'yyyy-mm-dd'), 'Wschowa', '63103068911', 1, 'OPK887654', 'M', null, 'Polna', '2', null,
        'A5', 'Barbara', 'Roman', null, null);
/
INSERT INTO KADRY.pracownicy (id, imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('b06d4267-698b-4227-b268-c55322cc29ae', 'Mariusz', 'Wolski', to_date('2001-03-15', 'yyyy-mm-dd'), 'Wschowa', '01131556832', 2, 'DE87WS76', 'M', null, 'Podgórna', '11', '2',
        'A6', 'Karolina', 'Paweł', null, null);

--------------------------------------------------------------
----------------  TYPY UMÓW

INSERT INTO typum (NAZWA, NR_TYT_ZUS, CZY_CHOR, CZY_REN, CZY_EMER, CZY_ZDROW, CZY_FP, CZY_FGSP, CZY_URLOP, CZY_AB_CHOR, NRM_CZAS_PRAC, STOG, STZW, STWS, STJB, RODZ_UM)
VALUES ('Umowa o pracę', '0110', '1', '1', '1', '1', '1', '0', '1', '1', F_HOURS_TO_MIN(8), '1', '1', '1', '1', 0);

INSERT INTO typum (NAZWA, NR_TYT_ZUS, CZY_CHOR, CZY_REN, CZY_EMER, CZY_ZDROW, CZY_FP, CZY_FGSP, CZY_URLOP, CZY_AB_CHOR, NRM_CZAS_PRAC, STOG, STZW, STWS, STJB, RODZ_UM)
VALUES ('Umowa zlecenie', '0410', '0', '0', '0', '0', '0', '0', '0', '0', F_HOURS_TO_MIN(0), '0', '0', '0', '0', 1);


--------------------------------------------------------------
----------------  STANOWISKA

-- INSERT INTO (NAZWA, KOD_GUS) VALUE(DANE ZE SŁOWNIKA XLS)

----------------  UMOWY

INSERT INTO umowy (DTZAW, DTROZ, ZASAD, ID_STANOW, ID_TYPUM, ID_PRC, NR_TYT_ZUS, CZY_PKZP, CZY_CHOR, CZY_REN, CZY_EMER, CZY_ZDROW, CZY_FP, CZY_FGSP, CZY_URLOP, CZY_AB_CHOR,
                   NRM_CZAS_PRAC, STOG, STZW, STWS, STJB)
VALUES (to_date('2008-01-01', 'yyyy-mm-dd'), NULL, 3500, 747, 1, 1, '0110', 1, '1', '1', '1', '1', '1', '0', '1', '1', F_HOURS_TO_MIN(8), '1', '1', '1', '1');

--------------------------------------------------------------
---------------- PARAMETRY PKZP 

INSERT INTO pkzp_param (forma, ile_rat, sklad, wklad)
VALUES (0, 12, 3, 1);

--------------------------------------------------------------
---------------- OPERATORZY

BEGIN
    KADRY.OPER_SECURITY.ADD_OPER('f177692b-b44f-4a38-bb34-c2d3dfa5790f', 'm.matysek', 'secret', 'Michał', 'Matysek');
END;

BEGIN
    KADRY.OPER_SECURITY.ADD_OPER('4c3d2a3b-ff96-4172-a288-97d2fa872f24', 'j.nowacki', 'secret', 'Jakub', 'Nowacki');
END;
