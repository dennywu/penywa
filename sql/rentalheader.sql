CREATE TABLE rentalheader
(
  rentalid character varying(1000) NOT NULL,
  rentralno character varying(250),
  transactiondate date,
  duedate date,
  custid character varying(1000),
  CONSTRAINT pk_rentalheader PRIMARY KEY (rentalid )
)
WITH (
  OIDS=FALSE
);
ALTER TABLE rentalheader
  OWNER TO postgres;
