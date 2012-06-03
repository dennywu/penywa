-- Table: tblrentalheader

-- DROP TABLE tblrentalheader;

CREATE TABLE tblrentalheader
(
  rentalid uuid,
  custid integer,
  rentalno character varying(250),
  transactiondate date,
  duedate date
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblrentalheader
  OWNER TO dny;
