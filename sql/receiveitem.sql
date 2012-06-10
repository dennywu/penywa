CREATE TABLE tblreceiveitem
(
  receiveid uuid,
  rentalid uuid,
  denda numeric,
  payamount numeric,
  total numeric,
  totalafterdenda numeric
)
WITH (
  OIDS=FALSE
);
ALTER TABLE tblreceiveitem
  OWNER TO postgres;
