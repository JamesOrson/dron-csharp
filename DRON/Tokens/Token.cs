namespace DRON.Tokens
{
    internal abstract class Token
    {
        #region Public

        #region Members
        internal readonly TokenKind Kind;
        #endregion

        #endregion
        
        #region Protected
        
        #region Constructors
        protected Token(TokenKind kind)
        {
            Kind = kind;
        }
        #endregion

        #endregion
    }
}