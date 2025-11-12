import Skeleton from "react-loading-skeleton";
import "react-loading-skeleton/dist/skeleton.css";

interface SkeletonLoaderProps {
    type: "list" | "form" | "card";
    count?: number;
}

const SkeletonLoader = ({ type, count = 1 }: SkeletonLoaderProps) => {
    const getRandomWidth = (min: number, max: number) => {
        return Math.floor(Math.random() * (max - min + 1) + min);
    };

    if (type === "list") {
        return (
            <>
                {[...Array(count)].map((_, index) => (
                    <div
                        key={index}
                        style={{
                            display: "flex",
                            alignItems: "center",
                            gap: "16px",
                            padding: "16px",
                            marginBottom: "12px",
                            borderRadius: "8px",
                            backgroundColor: "var(--surface)",
                        }}
                    >
                        <Skeleton circle width={48} height={48} />
                        <div style={{ flex: 1 }}>
                            <Skeleton width={`${getRandomWidth(40, 70)}%`} height={20} style={{ marginBottom: "8px" }} />
                            <Skeleton width={`${getRandomWidth(30, 50)}%`} height={16} />
                        </div>
                        <div style={{ display: "flex", gap: "8px" }}>
                            <Skeleton width={80} height={32} borderRadius={6} />
                            <Skeleton width={80} height={32} borderRadius={6} />
                        </div>
                    </div>
                ))}
            </>
        );
    }

    if (type === "form") {
        return (
            <div style={{ display: "flex", flexDirection: "column", gap: "20px" }}>
                {[...Array(count)].map((_, index) => (
                    <div key={index}>
                        <Skeleton width={`${getRandomWidth(20, 40)}%`} height={16} style={{ marginBottom: "8px" }} />
                        <Skeleton height={48} borderRadius={8} />
                    </div>
                ))}
                <div style={{ display: "flex", gap: "12px", marginTop: "8px" }}>
                    <Skeleton width={120} height={44} borderRadius={8} />
                    <Skeleton width={120} height={44} borderRadius={8} />
                </div>
            </div>
        );
    }

    if (type === "card") {
        return (
            <>
                {[...Array(count)].map((_, index) => (
                    <div
                        key={index}
                        style={{
                            padding: "24px",
                            borderRadius: "12px",
                            backgroundColor: "var(--surface)",
                            marginBottom: "16px",
                        }}
                    >
                        <Skeleton width={`${getRandomWidth(50, 80)}%`} height={24} style={{ marginBottom: "16px" }} />
                        <Skeleton count={3} height={16} style={{ marginBottom: "8px" }} />
                        <div style={{ display: "flex", gap: "12px", marginTop: "16px" }}>
                            <Skeleton width={100} height={36} borderRadius={6} />
                            <Skeleton width={100} height={36} borderRadius={6} />
                        </div>
                    </div>
                ))}
            </>
        );
    }

    return null;
};

export default SkeletonLoader;
