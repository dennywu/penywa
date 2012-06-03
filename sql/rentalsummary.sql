CREATE TABLE tblrentalsummary
(
  rentalid character varying(1000),
  total numeric
)
WITH (
  OIDS=FALSE
);
ALTER TABLE rentalsummary
  OWNER TO postgres;
