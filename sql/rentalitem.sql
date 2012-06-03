-- Table: tblrentalitem

-- DROP TABLE tblrentalitem;

CREATE TABLE tblrentalitem
(
  id bigserial NOT NULL,
  rentalid uuid,
  itemid integer,
  description character varying(250),
  qty integer,
  harga numeric,
  total numeric
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblrentalitem
  OWNER TO dny;
