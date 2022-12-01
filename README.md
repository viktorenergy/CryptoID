# CryptoID
  
Encrypts and decrypts ints to a short string.  
Useful for hiding real ids. E.g.:  
1 (one) can be "4nb", "ikr" or even "_b7". So you can use readable string to show user message without giving him the real error Id.  
At the same time, the string is being converted back to integer.  
Easy to hack, don't use for secret info.  
  
Example:  
``string encryptedResult = CryptoIdentity.Encript(394234);  
// encryptedResult equals "c7mvop"  
int decryptedValue = CryptoIdentity.Decrypt(encryptedResult);  
// decryptedValue is 394234 again  ``

