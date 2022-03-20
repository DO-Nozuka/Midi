namespace Dono.Midi
{
    public class SMFInfo
    {
        //分解能
        //フォーマット(1以外受け付けないけど。)
        //トラック数(計算すれば出るから不要)
        public int Format { get; private set; }
        public int TrackCount { get; private set; }
        public int Division { get; private set; }


        public SMFInfo(int format, int trackCount, int division)
        {
            Format = format;
            TrackCount = trackCount;
            Division = division;
        }
    }
}