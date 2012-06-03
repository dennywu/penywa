-- Table: tblrentalsummary

-- DROP TABLE tblrentalsummary;

CREATE TABLE tblrentalsummary
(
  rentalid uuid,
  total numeric
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblrentalsummary
  OWNER TO dny;
