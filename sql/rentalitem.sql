CREATE TABLE tblrentalitem
(
  itemid character varying(1000) NOT NULL,
  rentalid character varying(1000),
  partname character varying(250),
  description character varying(250),
  qty integer,
  harga numeric,
  total numeric,
  CONSTRAINT pk_rentalitem PRIMARY KEY (itemid )
)
WITH (
  OIDS=FALSE
);
ALTER TABLE rentalitem
  OWNER TO postgres;
