namespace IMustafaZeynali.IResultPattern
{
    internal static class ReulstPatternExtenssion
    {

        internal static bool CalculateIsSuccess(ResultStatus statusCode)
        {
            switch (statusCode)
            {
                case ResultStatus.Success:
                    return true;

                case ResultStatus.Created:
                    return true;

                case ResultStatus.NoContent:
                    return true;
            }

            return false;
        }

    }
}