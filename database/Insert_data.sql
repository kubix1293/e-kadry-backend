----------------  PRACOWNICY
INSERT INTO pracownicy (imie,nazwisko,dtur,misc_uro,pesel,dok_typ,nr_dok,plec,id_misc,ulica,nr_dom,nr_lok,nr_akt,imie_mat,imie_ojc,tele,id_oper)
VALUES ('JAKUB','NOWACKI',to_date('1993-02-01','yyyy-mm-dd'),'LESZNO','93020100012',1,'CJU938487','M',null,'DASZYŃSKIEGO','24','5','A1','RENATA','WLADYSLAW','509677027',null);
\
INSERT INTO pracownicy (imie,nazwisko,dtur,misc_uro,pesel,dok_typ,nr_dok,plec,id_misc,ulica,nr_dom,nr_lok,nr_akt,imie_mat,imie_ojc,tele,id_oper)
VALUES ('PAULINA','KWIAT',to_date('1997-12-05','yyyy-mm-dd'),'LESZNO','97120510124',1,'CLD542156','K',null,'POLNA','13A',NULL,'A4','KRYSTYNA','ADAM','605486689',null);
\
INSERT INTO pracownicy (imie,nazwisko,dtur,misc_uro,pesel,dok_typ,nr_dok,plec,id_misc,ulica,nr_dom,nr_lok,nr_akt,imie_mat,imie_ojc,tele,id_oper)
VALUES ('ALEKSANDER','NOWAK',to_date('1989-09-21','yyyy-mm-dd'),'LASOCICE','89092100335',1,'CDP945427','M',null,'KOSYNIERÓW','5',null,'A2','MARLENA','ADAM',null,null);
\
INSERT INTO pracownicy (imie,nazwisko,dtur,misc_uro,pesel,dok_typ,nr_dok,plec,id_misc,ulica,nr_dom,nr_lok,nr_akt,imie_mat,imie_ojc,tele,id_oper)
VALUES ('MARLENA','KOWALSKA',to_date('1976-07-12','yyyy-mm-dd'),'LESZNO','76071225228',1,'CDU765412','K',null,'NIEPODLEGŁOŚCI','34','12','A3','AGATA','BRONISŁAW',null,null);
\
INSERT INTO pracownicy (imie,nazwisko,dtur,misc_uro,pesel,dok_typ,nr_dok,plec,id_misc,ulica,nr_dom,nr_lok,nr_akt,imie_mat,imie_ojc,tele,id_oper)
VALUES ('BARTOSZ','MOLIK',to_date('1963-10-30','yyyy-mm-dd'),'WSCHOWA','63103068911',1,'OPK887654','M',null,'POLNA','2',null,'A5','BARBARA','ROMAN',null,null);
\
INSERT INTO pracownicy (imie,nazwisko,dtur,misc_uro,pesel,dok_typ,nr_dok,plec,id_misc,ulica,nr_dom,nr_lok,nr_akt,imie_mat,imie_ojc,tele,id_oper)
VALUES ('MARIUSZ','WOLSKI',to_date('2001-03-15','yyyy-mm-dd'),'WSCHOWA','01131556832',2,'DE87WS76','M',null,'PODGÓRNA','11','2','A6','KAROLINA','PAWEŁ',null,null);

--------------------------------------------------------------

----------------  TYPUM

INSERT INTO typum (NAZWA,NR_TYT_ZUS,CZY_CHOR,CZY_REN,CZY_EMER,CZY_ZDROW,CZY_FP,CZY_FGSP,CZY_URLOP,CZY_AB_CHOR,NRM_CZAS_PRAC,STOG,STZW,STWS,STJB,RODZ_UM)
VALUES ('UMOWA O PRACĘ', '0110', '1','1','1','1','1','0','1','1', F_HOURS_TO_MIN(8), '1','1','1','1',0);

--------------------------------------------------------------