namespace VAT
{
    public class VatService : EntityService<Vat>, IVatService
    {
        IUnityOfWork _unitOfWork;
        IVatRepository _vatRepository;

        public VatService(IUnityOfWork unitOfwork, IVatRepository vatRepository) : base (unitOfwork, vatRepository)
        {
            _unitOfWork = unitOfwork;
            _vatRepository = vatRepository;
        }

        public Vat GetById(int id)
        {
            return _vatRepository.GetById(id);
        }
    }
}
