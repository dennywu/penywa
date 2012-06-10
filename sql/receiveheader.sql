CREATE TABLE tblreceiveheader
(
  receiveid uuid,
  receiveno character varying(250),
  custid integer,
  receivedate date
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblreceiveheader
  OWNER TO postgres;
