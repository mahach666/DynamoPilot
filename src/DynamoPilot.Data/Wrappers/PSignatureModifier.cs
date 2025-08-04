using Ascon.Pilot.SDK;
using DynamoPilot.Data.Contracts;
using System;

namespace DynamoPilot.Data.Wrappers
{
    public class PSignatureModifier : IWrapper
    {
        private readonly ISignatureModifier _signatureModifier;
        public PSignatureModifier(ISignatureModifier signatureModifier)
        {
            _signatureModifier = signatureModifier;
        }

        public PSignatureBuilder Add(Guid id)
        {
            return new(_signatureModifier.Add(id));
        }

        public PSignatureModifier Remove(Predicate<ISignature> findSignatureRequest)
        {
            _signatureModifier.Remove(findSignatureRequest);
            return this;
        }

        public PSignatureModifier SetIsAdvancementRequired(Guid id, bool isAdvancementRequired)
        {
            _signatureModifier.SetIsAdvancementRequired(id, isAdvancementRequired);
            return this;
        }

        public PSignatureModifier SetLastSignCadesType(Guid id, CadesType cadesType)
        {
            _signatureModifier.SetLastSignCadesType(id, cadesType);
            return this;
        }

        public PSignatureModifier SetPublicKeyOid(Guid id, string publicKeyOid)
        {
            _signatureModifier.SetPublicKeyOid(id, publicKeyOid);
            return this;
        }

        public void SetSign(Guid id, string sign)
        {
            _signatureModifier.SetSign(id, sign);
        }

        public object Unwrap()
        {
            return _signatureModifier;
        }
    }
}
