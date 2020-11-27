----------------  PRACOWNICY

INSERT INTO KADRY.pracownicy (imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('Jakub', 'Nowacki', to_date('1993-02-01', 'yyyy-mm-dd'), 'Leszno', '93020100012', 1, 'CJU938487', 'M', null, 'Daszyńskiego', '24', '5', 'A1', 'Renata', 'Władysław', '509677027', null);
/
INSERT INTO KADRY.pracownicy (imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('Paulina', 'Kwiat', to_date('1997-12-05', 'yyyy-mm-dd'), 'Leszno', '97120510124', 1, 'CLD542156', 'K', null, 'Polna', '13A', NULL, 'A4', 'Krystyna', 'Adam', '605486689', null);
/
INSERT INTO KADRY.pracownicy (imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('Aleksander', 'Nowak', to_date('1989-09-21', 'yyyy-mm-dd'), 'Lasocice', '89092100335', 1, 'CDP945427', 'M', null, 'Kosynierów', '5', null, 'A2', 'Marlena', 'Adam', null, null);
/
INSERT INTO KADRY.pracownicy (imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('Marlena', 'Kowalska', to_date('1976-07-12', 'yyyy-mm-dd'), 'Leszno', '76071225228', 1, 'CDU765412', 'K', null, 'Nniepodległości', '34', '12', 'A3', 'Agata', 'Bronisław', null, null);
/
INSERT INTO KADRY.pracownicy (imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('Bartosz', 'Molik', to_date('1963-10-30', 'yyyy-mm-dd'), 'Wschowa', '63103068911', 1, 'OPK887654', 'M', null, 'Polna', '2', null, 'A5', 'Barbara', 'Roman', null, null);
/
INSERT INTO KADRY.pracownicy (imie, nazwisko, dtur, misc_uro, pesel, dok_typ, nr_dok, plec, id_misc, ulica, nr_dom, nr_lok, nr_akt, imie_mat, imie_ojc, tele, id_oper)
VALUES ('Mariusz', 'Wolski', to_date('2001-03-15', 'yyyy-mm-dd'), 'Wschowa', '01131556832', 2, 'DE87WS76', 'M', null, 'Podgórna', '11', '2', 'A6', 'Karolina', 'Paweł', null, null);

--------------------------------------------------------------

----------------  TYPUM

INSERT INTO KADRY.typum (NAZWA, NR_TYT_ZUS, CZY_CHOR, CZY_REN, CZY_EMER, CZY_ZDROW, CZY_FP, CZY_FGSP, CZY_URLOP, CZY_AB_CHOR, NRM_CZAS_PRAC, STOG, STZW, STWS, STJB, RODZ_UM)
VALUES ('UMOWA O PRACĘ', '0110', '1', '1', '1', '1', '1', '0', '1', '1', KADRY.F_HOURS_TO_MIN(8), '1', '1', '1', '1', 0);

--------------------------------------------------------------


BEGIN KADRY.OPER_SECURITY.ADD_OPER(sys_guid(), 'admin', 'secret', 'John', 'Galt'); END;