<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>  <body>
			<h3>Member File</h3>
			<table border="1">
				<tr bgcolor="black" style="color: gray" > 
					<td><b>Name</b></td>
          <td><b>Salt</b></td>
					<td><b>Password</b></td> 
				</tr>
				<xsl:for-each select="Members/Member">
					<tr style="font-size: 10pt; font-family: verdana;">
						<td><xsl:value-of select="Name"/></td>
            <td><xsl:value-of select="Salt"/></td>
						<td><xsl:value-of select="Password"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>