SET SCAN OFF
SET TIMING ON

PROMPT install packages
@AS_PDF3_MOD.pls
@PK_JRXML2PDF_LOG.pls
@PK_JRXML2PDF_TYPES.pls
@PK_JRXML2PDF_UTIL.pls
@PK_JRXML2PDF_CHARTS.pls
@PK_JRXML2PDF_LOADER.pls
@PK_JRXML2PDF_REPGEN.pls

PROMPT finished

