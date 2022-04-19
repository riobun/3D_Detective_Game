using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;

public class NewItemManager
{
    private static NewItemManager instance;
    public static NewItemManager Instance
    {
        get
        {
            if (instance == null) instance = new NewItemManager();
            return instance;
        }
    }

    private JsonData itemConfig;
    public List<bagItem> bagItemList;

    private int[] IDs = { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
    private int[] locates = { 4,4,4,4,3,3,3,3,2,2,2,5,5,0,0,0,1,1,2};
    private int[] isFinds = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 };
    private string[] names = { "报纸", "电脑邮件", "助理", "手机短信", "日记", "手机导航", "酒柜里的红酒", "电脑邮件", "手机短信", "名片", "病历单", "实验项目书", "手术报告", "电脑邮件", "神魂颠倒药加密文件", "随身挎包", "一杯红酒", "“三步倒”药瓶", "尸检" };
    private string[] descs = {
        "报纸上几条新闻：“M公司近期新上市药物产品被疑窃取N公司研发成果”、“M公司引领医药潮流，新上市产品”神魂颠倒“药或真能使人神魂颠倒”。报纸上面有李老板的笔迹：“不要脸！丧心病狂！”",
        "助理发来的短信：“老板，查出来了，是M公司的一名员工干的，肯定是甄某指使。现在这名员工已经辞职，他们高层不认这件事。”",
        "李总曾经派私家侦探调查过甄某，知道甄某在念稿致辞时摸头发和舔手翻页的习惯。",
        "当天下午13:30，与助理发的短信，甄某说有个合作要谈，我去看看情况，会随机应变",
        "日记中写着“该死的甄某，居然为了维护自己的权力，骗走了父亲当年留给我的绝大部分的股份，还把我当一个小员工一样呼来喝去。总有一天，我会让你付出代价，拿回属于我自己的东西。”",
        "案发当天下午13:30搜索了“山秋路233号”",
        "一瓶启封过的红酒，是甄某喜欢的红酒的牌子，里面检测出安眠药成分。（当酒类与安眠药合用时有诱发猝死的可能。）",
        "当天下午13:25发给关系亲密的药店老板的邮件：“该死的甄某突然让我下午去一个地方，不知道他安的什么心，我倒要去看看他又有什么要紧事。我已经都准备好了，就等着下午亲手给他倒上。事成之后我可要好好谢你。”",
        "手机里有案发当天下午13:05收到的短信：“有人要在酒会上杀我，来不及了，下午就安排人动手。”发件人为甄某。",
        "王专家。X医院主治医生。X医院地址：S市山秋路233号。",
        "患者：甄某。病情：肺癌晚期。诊断人：王专家。",
        "人体器官移植实验次数为6次，其中成功1次，成功率为16.667%。实验说明：同时实验的两人，实验后的苏醒时间由所在身体素质决定，20分钟到40分钟不等。时间为半年前。背面有甄某的签字：已知晓。M公司将尽全力给X实验室提供资源帮助，作为回报，我需要王专家作为私人医生对我进行全力治疗，月工资1000元。",
        "报告打印时间为当天下午14:30。配型结果：甄弟弟-配型成功，李老板-配型成功。换脑手术成功率：40%，人在手术中的死亡率：0.1%。成功后，手术者脑部均会产生轻微移植排斥反应。如果手术不成功，另一人需在未苏醒时被护士喷上“快速遗忘药”并秘密运出医院。如果手术成功，另一人等甄某苏醒后自行安排。",
        "当天发出的邮件，收件人是李老板。邮件内容：“今天13:50，你来山秋路233号，X医院新研究出了一种新技术，没准我们两公司可以合作一下。具体面谈。”",
        "该药会使服用者精神错乱。此时他人可通过服用对应药物“灵魂控制”使自己的精神进入对方大脑，从而达到一个大脑同时控制两个肉体的效果。药效持续时间：2-5h。“灵魂控制”药不对外发行，仅在M公司和X医院内部流通。",
        "有一瓶用过的“一喷即晕药”和“快速遗忘”药。",
        "经检测，不含安眠药成分。负责人说甄某只喝一个牌子的红酒，但那瓶酒在当天上午不见了，所以只好拿别的代替。",
        "该药在服用后3-10分钟见效，中毒者会表情痛苦地猝死，药瓶上除了甄某指纹外，未检测到其他指纹。",
        "1. 死者的死是因为中毒。2. 死者的脑部有轻微的移植排斥反应。3. 死者的口腔和食道未检测出红酒残留。4. 死者的发胶上有“一舔即死”药，致死时间为3秒。",

    };

    public void loadItemConfig()
    {
        if (this.bagItemList == null)
        {
            this.bagItemList = new List<bagItem>();
        }
        //读文件
        //this.itemConfig = JsonMapper.ToObject(File.ReadAllText(Application.streamingAssetsPath + "/item.json",Encoding.GetEncoding("GB2312")));
        //this.decodeJson();

        //写在脚本中的数据
        this.setData();
    }

    private void decodeJson()
    {
        for( int i = 0; i < this.itemConfig.Count; i++)
        {
            int ID = (int)this.itemConfig[i]["ID"];
            string name = this.itemConfig[i]["name"].ToString();
            string desc = this.itemConfig[i]["desc"].ToString();
            int locate = (int)this.itemConfig[i]["locate"];
            int isFind = (int)this.itemConfig[i]["isFind"];
            

            bagItem item = new bagItem(ID,name,desc,locate,isFind);
            this.bagItemList.Add(item);
        }
    }

    private void setData()
    {
        for (int i = 0; i < 19; i++)
        {
            int ID = i + 1;
            string name = this.names[i];
            string desc = this.descs[i];
            int locate = this.locates[i];
            int isFind = 0;


            bagItem item = new bagItem(ID, name, desc, locate, isFind);
            this.bagItemList.Add(item);
        }

    }

}
